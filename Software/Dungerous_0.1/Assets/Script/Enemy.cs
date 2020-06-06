using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject DeathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 0.4f);
    }
}