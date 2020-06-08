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
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Clamp arguments: what we're going to be clamping, two positions that we want to clamp in between 
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // Parameter: starting position, ending position, what speed we want to use
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
