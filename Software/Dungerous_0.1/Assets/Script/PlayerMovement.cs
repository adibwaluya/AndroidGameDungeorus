using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;

    public Rigidbody2D rb;
    public Animator animator;

    // Reference to Joystick
    // public Joystick joystick;

    // store x and y 
    Vector2 movement;

    //to detect where the character is moving
    public static float moveX;
    public static float moveY;

    // Update is called once per frame
    void Update()
    {
        
        // Input from keyboard
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        

        // Input from Joystick
        /*
        if(joystick.Horizontal >= .1f)
        {
            movement.x = moveSpeed;
        } else if (joystick.Horizontal <= -.1f)
        {
            movement.x = -moveSpeed;
        }
        else
        {
            movement.x = 0;


        }

        if (joystick.Vertical >= .2f)
        {
            movement.y = moveSpeed;
            
        }
        else if (joystick.Vertical <= .2f)
        {
            movement.y= -moveSpeed;
            
        }
        else
        {
            movement.y = 0;
            
        }
        */

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Movement
        // Move rigid body to a new position
        // rb.positon = current position
        // To control the speed of the movement, * moveSpeed
        // Time.fixedDeltaTime = the amount of time that has elapsed since...
        // ... the last time the function was called
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x < 0) {moveX = -1;}
        if (movement.x > 0) { moveX = 1;}
        if (movement.x == 0) { moveX = 0;}

        if (movement.y < 0) { moveY = -1;}
        if (movement.y > 0) { moveY = 1;}
        if (movement.y == 0) { moveY = 0;}


    }
}