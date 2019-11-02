using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int moveSpeed = 3, jumpSpeed = 30;

    private static bool grounded;
    
    private Rigidbody2D rb;

    private int tempMoveSpeed;
    // Gets the RigidBody and sets the temporary moveSpeed for sprinting.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tempMoveSpeed = moveSpeed * 2;
    }
    
    
    void Update()
    {
        //Technically not proper way of doing movement due to hard coded keys, but this will work fine.
        //Depending on the key pressed, the player moves a direction at a certain speed, and is unaffected by the
        //Frame rate.
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        }
        
        //Jumping uses the RigidBody to jump.
        if (Input.GetKey(KeyCode.W))
        {
            if (grounded)
            {
                grounded = false;
                rb.AddForce(Vector2.up * jumpSpeed);
            }
        }
    
        //Sprinting mechanic doubles the speed until shift is let go.
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = tempMoveSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = (tempMoveSpeed / 2);
        }
    }

    //Set method to allow other classes to change the grounded status.
    public static void SetGrounded (bool newStatus)
    {
        grounded = newStatus;
    }
}
