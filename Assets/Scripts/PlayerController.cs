using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D MyRB;
    private Vector2 BasePos;
    private float JumpCount, WallJumpDir;
    private bool OnWall, HasThrownSpell, JumpFromWall, CanBeHurt;
    private Vector3 NewPos;
    private int LivePoints;
    private AudioSource My_As;

    public float Speed, JumpHeight, SecondsAfterSpell, DamageCooldown;
    public GameObject SpellGuide;
    public GameObject[] SpellList;
    public AudioClip JumpSound, DJumpSound, WJumpSound, HurtSound, DeathSound;
    public AudioClip[] SpellSounds;

    private void Start()
    {
        My_As = GetComponent<AudioSource>();
        CanBeHurt = true;
        LivePoints = 3;
        JumpCount = 2;
        MyRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            Instantiate(SpellGuide);
        }
        CheckJump();
        if (!JumpFromWall)
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpFromWall = false;
            OnWall = false;
            JumpCount = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            OnWall = true;
            MyRB.velocity = Vector2.zero;
            MyRB.gravityScale = 0.1f;
            WallJumpDir = collision.GetContact(0).point.x - transform.position.x;
            JumpCount = 2;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (CanBeHurt)
            {
                Destroy(collision.gameObject);
                LivePoints--;
                if (LivePoints <= 0)
                {
                    DeathTrigger();
                    return;
                }
                My_As.PlayOneShot(HurtSound);
                StartCoroutine(DamageCooldownTimer());
                CanBeHurt = false;
                //TODO SpriteChange
            }
            else if (!CanBeHurt)
            {
                Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>(), true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpCount--;
            My_As.PlayOneShot(JumpSound);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            MyRB.gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathTrigger")){
            DeathTrigger();
        }
    }

    public void SpellThrow(int spellID)
    {
        NewPos = new Vector3(transform.position.x +2 , transform.position.y, transform.position.z);
        Instantiate(SpellList[spellID], NewPos, transform.rotation);
        My_As.PlayOneShot(SpellSounds[spellID]);
        HasThrownSpell = true;
        StartCoroutine(WaitForSpell());
    }

    private void CheckJump()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended && JumpCount != 0 && !HasThrownSpell)
            {
                if (OnWall)
                {
                    My_As.PlayOneShot(WJumpSound);
                    MyRB.AddForce(new Vector2(-WallJumpDir * 10, JumpHeight * 2), ForceMode2D.Impulse);
                    OnWall = false;
                    MyRB.gravityScale = 1;
                    JumpFromWall = true;
                }
                else
                {
                    My_As.PlayOneShot(DJumpSound);
                   MyRB.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
                    JumpCount--;
                }
            }
        }
    }

    private void DeathTrigger()
    {
        My_As.PlayOneShot(DeathSound);
        Debug.Log("Dead");
    }

    IEnumerator WaitForSpell()
    {
        yield return new WaitForSeconds(SecondsAfterSpell);
        HasThrownSpell = false;
    }

    IEnumerator DamageCooldownTimer()
    {
        yield return new WaitForSeconds(DamageCooldown);
        CanBeHurt = true;
        //TODO Sprite change
        Debug.Log("I'm better");
    }
}
