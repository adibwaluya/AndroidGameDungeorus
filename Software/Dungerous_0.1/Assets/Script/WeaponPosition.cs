using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WeaponPosition : MonoBehaviour
{
    //private Vector3 origPos;
    //private Vector3 moveDirection;

    public static float moveX;
    public static float moveY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ////Getting the current direction the player is facing
        //moveDirection = gameObject.transform.position - origPos;

        //origPos = transform.position;

        //if (moveDirection != Vector3.zero)
        //{
        //    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
        //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //}
        //else
        //{
        //    transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        //}

        moveX = PlayerMovement.moveX;
        moveY = PlayerMovement.moveY;

        //if (moveX == -1)
        //{
        //    transform.localPosition = new Vector3((transform.position.x - 0.01f), (transform.position.y - 0.01f), 0);
        //    transform.Rotate(0, 0, 90);
        //}

    }
}
