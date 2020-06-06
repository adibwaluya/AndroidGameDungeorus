using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    // store x and y 
    Vector2 movement;

    //to detect where the character is moving
    public static float moveX;
    public static float moveY;

    // Update is called once per frame
    void Update()
    {
        // Input

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //float _xMov = Input.GetAxisRaw("Horizontal");
        //float _yMov = Input.GetAxisRaw("Vertical");

        // movement = movement.normalized;
        //Vector2 movHorizontal = transform.right * _xMov;
        //Vector2 movVertical = transform.up * _yMov;
        //Vector2 velocity = (movHorizontal + movVertical).normalized * moveSpeed;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        /*
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        Vector2 _movHorizontal = transform.right * _xMov;
        Vector2 _movVertical = transform.up * _yMov;

        Vector2 _velocity = (_movHorizontal + _movVertical).normalized * moveSpeed;

        rb.MovePosition(rb.position + _velocity * Time.deltaTime);
        */

        // rb.MovePosition(rb.position + velocity * Time.deltaTime);
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