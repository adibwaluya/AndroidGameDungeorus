using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);



        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                if (randomSpot < moveSpots.Length)
                {
                    randomSpot += 1;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
               
            }
        }

        if (randomSpot == moveSpots.Length)
        {
            randomSpot = 0;
        }
    }
}
