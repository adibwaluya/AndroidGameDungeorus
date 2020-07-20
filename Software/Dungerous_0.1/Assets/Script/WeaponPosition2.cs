using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPosition2 : MonoBehaviour
{

    private Transform childTransform;

    private Vector3 origPos;
    private Vector3 moveDirection;

    private float old_posY;
    private float old_posX;

    private float diffX;
    private float diffY;

    // Start is called before the first frame update
    void Start()
    {
        childTransform = transform.Find("Weapon");
        Debug.Log(childTransform.position);
        Debug.Log(childTransform.localPosition);
        childTransform.position = transform.position + new Vector3(-0.22f, -0.45f, 0);
        old_posY = gameObject.transform.position.y;
        old_posX = gameObject.transform.position.x;
    }

    void Update()
    {
        //old_posY = gameObject.transform.position.y;
        //old_posX = gameObject.transform.position.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Getting the current direction the player is facing
        //moveDirection = gameObject.transform.position - origPos;
        //var localDirection = transform.InverseTransformDirection(moveDirection);
        //origPos = transform.position;

        diffX = Math.Abs(old_posX - transform.position.x);
        diffY = Math.Abs(old_posY - transform.position.y);


        //Muss noch korrigiert werden, damit sich die Waffenposition ändert
        if (old_posY > transform.position.y && diffY > diffX )
        {
            //Weapon position for down-movement                         
            childTransform.position = transform.position + new Vector3(0f, -0.55f, 0);
            childTransform.rotation = Quaternion.AngleAxis(180f, Vector3.forward);
        }

        if (old_posY < transform.position.y && diffY > diffX)
        {
            //Weapon position for up-movement
            childTransform.position = transform.position + new Vector3(0f, 0.3f, 0);
            childTransform.rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        }


        if (old_posX > transform.position.x && diffX > diffY)
        {
            //Weapon position for left-movement                         
            childTransform.position = transform.position + new Vector3(-.3f, -0.5f, 0);
            childTransform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
        }

        if (old_posX < transform.position.x && diffX > diffY)
        {
            //Weapon position for right-movement
            childTransform.position = transform.position + new Vector3(.3f, -0.5f, 0);
            childTransform.rotation = Quaternion.AngleAxis(270f, Vector3.forward);
        }
        old_posX = gameObject.transform.position.x;
        old_posY = gameObject.transform.position.y;


    }
}
