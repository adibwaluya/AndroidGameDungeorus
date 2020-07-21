using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = .2f;

    public Rigidbody2D rb;
    public Animator animator;

    // Reference to Joystick
    public Joystick joystick;

    // store x and y 
    Vector2 movement;

    //to detect where the character is moving
    public static float moveX;
    public static float moveY;

    private float attackTime = 0.5f;
    private float attackCounter = 0.5f;
    private bool isAttacking;

    // Update is called once per frame
    void Update()
    {

        // Input from keyboard
        
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
        

        // Input from joystick
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        // Joystick Optimatization but incomplete
        /*
        if (joystick.Horizontal >= .2f || joystick.Vertical == 0)
        {
            movement.x = moveSpeed;
            movement.y = 0;
        } else if (joystick.Horizontal <= -.2f || joystick.Vertical == 0)
        {
            movement.x = -moveSpeed;
            movement.y = 0;
        } else if (joystick.Horizontal == 0 || joystick.Vertical >= .2f)
        {
            movement.x = 0;
            movement.y = moveSpeed;
        } else if (joystick.Horizontal == 0 || joystick.Vertical <= .2f)
        {
            movement.x = 0;
            movement.y = -moveSpeed;
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }
        */

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(isAttacking)
        {
            movement = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }
        if(CrossPlatformInputManager.GetButtonDown("Punch"))
        {
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            isAttacking = true;
        }
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