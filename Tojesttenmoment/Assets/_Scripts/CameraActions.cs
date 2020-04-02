using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActions : MonoBehaviour
{
    public Transform target, ball, bot;

    public float smoothSpeed = 0.075f;
    public Vector3 offset;
    public GameObject winGlasses;

    private Vector3 desiredPosition;

    void FixedUpdate()
    {
        if (ball.transform.position.x > -1.5f && !winGlasses.activeSelf) //Win Glasses means game over
        {
            desiredPosition = target.position + offset;
        } else desiredPosition = new Vector3(target.position.x, target.position.y, 0f) + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
