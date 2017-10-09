using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] Transform collisionPoint;
    Rigidbody2D rigid;


    public float movespeed = 10;
    [SerializeField]private float moveSpeedMultipier;

    [SerializeField]private float speedIncreaseMilestone;
    public float speedMilestoneCount;

    [SerializeField]private float jumpPower = 20;
    private float jumpCount = 1;
    private bool canDoubleJump;
    private bool stoppedJumping;

    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        speedMilestoneCount = speedIncreaseMilestone;
        canDoubleJump = false;
    }

    void FixedUpdate()
    {
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone += 100;

            movespeed = movespeed + moveSpeedMultipier;
        }


        rigid.velocity = new Vector2(movespeed, rigid.velocity.y);

        anim.SetFloat("Speed", rigid.velocity.x);
        anim.SetBool("Grounded", true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanJump())
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
                stoppedJumping = false;
                jumpCount = 0;
            }

            if (!CanJump() && canDoubleJump && jumpCount == 0)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
                stoppedJumping = false;
                canDoubleJump = false;
                jumpCount = 1;
            }
        }

        

        if (!CanJump())     
        {
            anim.SetBool("Grounded", false);
        }

    }


    bool CanJump()
    {
        canDoubleJump = true;
        return Physics2D.Raycast(collisionPoint.position, Vector2.down, 0);
    }
}
