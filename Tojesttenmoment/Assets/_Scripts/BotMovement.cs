using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public GameObject ball;
    public float xDetection, standardY;
    private Vector3 desiredPosition;
    private float smoothSpeed, smoothRotSpeed;
    public GameObject playerCol; //CHECK IF OBJECT IS ACTIVE TO TRACK OR NOT TO TRACK BALL POSITION


    private void Start()
    {
        standardY = transform.position.y;
    }

    void FixedUpdate()
    {
        if (ball.transform.position.x < xDetection && !playerCol.activeSelf)
        {
            desiredPosition = new Vector3(transform.position.x, ball.transform.position.y, ball.transform.position.z);
            if (desiredPosition.y < 2.5f)
                desiredPosition.y = 2.5f;
            smoothSpeed = 0.2f * Time.timeScale;
        }
        else
        {
            desiredPosition = new Vector3(transform.position.x, standardY, 0f);
            smoothSpeed = 0.03f * Time.timeScale;
        }
        smoothRotSpeed = 0.1f * Time.timeScale;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
     
        transform.position = smoothedPosition;

        Quaternion desiredRotation = Quaternion.Euler(-90f + transform.position.z * 10, transform.rotation.y, -90f);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothRotSpeed);
    }
}
