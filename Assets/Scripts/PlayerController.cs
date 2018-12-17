using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D MyRB;
    private Vector2 BasePos;
    private float JumpCount, WallJumpDir;
    private bool OnWall;

    public float Speed, JumpHeight;

    private void Start()
    {
        JumpCount = 2;
        MyRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckJump();
        transform.Translate(Vector2.right * Time.deltaTime * Speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpCount = 2;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            MyRB.velocity = new Vector2(0, 0);
            MyRB.gravityScale = 0;
            OnWall = true;
            WallJumpDir = collision.GetContact(0).point.x;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpCount--;
        }
    }

    private void CheckJump()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended && JumpCount != 0)
            {
                if (OnWall == true)
                {
                    MyRB.AddForce(new Vector2(WallJumpDir, JumpHeight), ForceMode2D.Impulse);
                }
                else
                {
                    MyRB.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
                    JumpCount--;
                }
            }
        }
    }
}
