using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D MyRB;
    private Vector2 BasePos;
    private float JumpCount;

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
                MyRB.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
                JumpCount--;
            }
        }
    }
}
