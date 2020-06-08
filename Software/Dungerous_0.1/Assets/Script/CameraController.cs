using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Stiff camera movement
        // transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

        if(transform.position != target.position)
        {
            // Parameter: starting position, ending position, what speed we want to use
            transform.position = Vector3.Lerp(transform.position, target.transform.position, smoothing);
        }
    }
}
