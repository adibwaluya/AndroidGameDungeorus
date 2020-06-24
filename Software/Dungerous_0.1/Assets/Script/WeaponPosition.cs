using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WeaponPosition : MonoBehaviour
{
    private Vector3 origPos;
    private Vector3 moveDirection;

    private float posX;
    private float posY;

    public GameObject Parent;
    public GameObject Weapon;

    void Start()
    {
        Parent = new GameObject();
        Weapon = new GameObject();

        Transform childTransform = transform.Find("Weapon");
        Debug.Log(childTransform.position);
        Debug.Log(childTransform.localPosition);
        childTransform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Getting the current direction the player is facing
        moveDirection = gameObject.transform.position - origPos;
        origPos = transform.position;

        posX = gameObject.transform.position.x - origPos.x;
        posY = gameObject.transform.position.y - origPos.y;

        //if (moveDirection != Vector3.zero)
        //{
        //    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
        //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //}
        //else
        //{
        //    transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        //}

        //if (posX < 0 )
        //{
        //    Weapon.transform.parent = Parent.transform;
        //    Weapon.transform.localPosition = new Vector3(10,20,0);
        //}
        //Weapon.transform.parent = Parent.transform;
        //Weapon.transform.localPosition = Vector3.zero;
        //Weapon.transform.localPosition = new Vector3(100, 200, 0);

    }
}
