using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff1Script : MonoBehaviour
{


    public Collider2D collision;
    // Update is called once per frame
    void FixedUpdate()
    {
        OnTriggerEnter2D(collision);

        //DestroyItem(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.)
        {
            Destroy(gameObject);
        }

    }

    private void DestroyItem(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }

}
