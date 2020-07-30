using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject DeathEffect;

    //public Transform Player;

    public Rigidbody2D rb;

    public Collider2D collision;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
        //Player = GameObject.FindWithTag("Character").transform;
    }

    void Update()
    {

<<<<<<< HEAD
        //Getting the direction to the player
        //Vector3 direction = Player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle - 90f;
        //direction.Normalize();
        //movement = direction;
=======
>>>>>>> 508b8e9bc81f40f8fc499de772433477a3f18b95
    }


    void FixedUpdate()
    {
<<<<<<< HEAD
        //moveEnemy(movement);
=======
        OnTriggerEnter2D(collision);
>>>>>>> 508b8e9bc81f40f8fc499de772433477a3f18b95
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

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            if (CrossPlatformInputManager.GetButtonDown("Punch"))
            {
                TakeDamage(40);
            }
            
        }

    }
    

}