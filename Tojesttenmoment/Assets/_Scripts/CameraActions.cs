using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActions : MonoBehaviour
{
    public Transform target, ball;

    public float smoothSpeed = 0.075f;
    public Vector3 offset;

    private Vector3 desiredPosition;

    void FixedUpdate()
    {
        if (ball.transform.position.x > -1.5f)
        {
            desiredPosition = target.position + offset;
        } else desiredPosition = new Vector3(target.position.x, target.position.y, 0f) + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    
        transform.LookAt(target);
    }
}
