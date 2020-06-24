using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPosition2 : MonoBehaviour
{
    private Transform childTransform;

    private Vector3 origPos;
    private Vector3 moveDirection;

    private float posX;
    private float posY;

    // Start is called before the first frame update
    void Start()
    {
        childTransform = transform.Find("Weapon");
        Debug.Log(childTransform.position);
        Debug.Log(childTransform.localPosition);
        childTransform.position = transform.position + new Vector3(-1.22f, -0.45f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Getting the current direction the player is facing
        moveDirection = gameObject.transform.position - origPos;
        origPos = transform.position;

        posX = gameObject.transform.position.x - origPos.x;
        posY = gameObject.transform.position.y - origPos.y;

        if (true)
        {
            //Weapon position for down-movement
            childTransform.position = transform.position + new Vector3(-0.22f, -0.45f, 0);
            //childTransform.rotation = Quaternion.AngleAxis(90, new Vector3(1,0,0));
        }
    }
}
