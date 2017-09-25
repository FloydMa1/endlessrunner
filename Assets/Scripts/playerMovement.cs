using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] Transform collisionPoint;
    Rigidbody2D rigid;
    private float movespeed = 5;
    private float jumpPower = 30;
    

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        rigid.velocity = new Vector2(movespeed, rigid.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
        }
    }

    bool CanJump()
    {
        return Physics2D.Raycast(collisionPoint.position, Vector2.down, 0);
    }
}
