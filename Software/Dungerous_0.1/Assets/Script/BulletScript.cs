using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public GameObject HitEffect;
    public int damage = 40;

    public Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);

            Destroy(effect, 0.4f);
            Destroy(gameObject);

            Debug.Log(collision.gameObject.name);
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

        Destroy(gameObject);

    }

}