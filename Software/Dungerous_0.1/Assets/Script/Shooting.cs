using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;


    public float bulletForce = 20f;
    private Vector2 screenBounds;
    private Vector3 origPos;
    private Vector3 moveDirection;

    void Start()
    {
        //Getting the screensize
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


    }

    void FixedUpdate()
    {
        //Getting the current direction the player is facing
        moveDirection = gameObject.transform.position - origPos;
        origPos = transform.position;

        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
            firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            firePoint.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        }
    }

    //Spawns bullets and add damage to it
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}