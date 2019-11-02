using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int moveSpeed = 3, jumpSpeed = 30;

    private static bool grounded;
    
    private Rigidbody2D rb;

    private int tempMoveSpeed;

    private float horizontalAxis, verticalAxis, sprintAxis;
    // Gets the RigidBody and sets the temporary moveSpeed for sprinting.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tempMoveSpeed = moveSpeed * 2;
    }
    
    
    void Update()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        verticalAxis = Input.GetAxisRaw("Vertical");
        sprintAxis = Input.GetAxisRaw("Sprint");
        
        Movement();
    }

    private void Movement()
    {
        //Using Unity Input System to use movement
        if (horizontalAxis >= 1f)
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        }
        else if (horizontalAxis <= -1f)
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        }
        
        //Jumping uses the RigidBody to jump.
        if (verticalAxis >= 1f)
        {
            if (grounded)
            {
                grounded = false;
                rb.AddForce(Vector2.up * jumpSpeed);
            }
        }
    
        //Sprinting mechanic doubles the speed until shift is let go.
        if (sprintAxis >= 1f)
        {
            moveSpeed = tempMoveSpeed;
        }

        if (sprintAxis <= 0f)
        {
            moveSpeed = (tempMoveSpeed / 2);
        }
    }

    //Set method to allow other classes to change the grounded status.
    public static void SetGrounded (bool newStatus)
    {
        grounded = newStatus;
    }

    public static bool GetGrounded()
    {
        return grounded;
    }
}
