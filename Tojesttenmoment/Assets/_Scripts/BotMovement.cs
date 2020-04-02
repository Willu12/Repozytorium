using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public Transform ball;
    public float xDetection, standardY;
    private Vector3 desiredPosition;
    public float smoothSpeed = 0.2f;
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
            smoothSpeed = 0.2f;
        }
        else
        {
            desiredPosition = new Vector3(transform.position.x, standardY, 0f);
            smoothSpeed = 0.03f;
        }
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
       
        transform.position = smoothedPosition;
    }
}
