using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int moveSpeed = 3, jumpSpeed = 30;

    private static bool grounded = false;
    
    private Rigidbody2D rb;

    private int tempMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tempMoveSpeed = moveSpeed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (grounded)
            {
                grounded = false;
                rb.AddForce(Vector2.up * jumpSpeed);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = tempMoveSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = (tempMoveSpeed / 2);
        }
    }

    public static void SetGrounded (bool newStatus)
    {
        grounded = newStatus;
    }
}
