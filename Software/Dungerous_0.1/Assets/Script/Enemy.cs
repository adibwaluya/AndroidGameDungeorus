using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject DeathEffect;

    //public Transform Player;

    public Rigidbody2D rb;

    public Collider2D collision;

    public float moveSpeed = 1f;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
        //Player = GameObject.FindWithTag("Character").transform;
    }

    void Update()
    {

    }


    void FixedUpdate()
    {
       
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    //Calculates enemy damage taken
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            ScoreScript.scoreValue += 870;
            Die();
        }
    }

    //Destroys enemy object
    void Die()
    {
        GameObject effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 0.4f);
    }

    void MeleeDamage(int damage)
    {

    }
}