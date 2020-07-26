using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    public Collider2D collision;
    public GameObject item;

    // update is called once per frame
        
    void FixedUpdate()
    {
        OnTriggerEnter2D(collision);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Character"))
        { 
            Destroy(item);
        }

    }

}
