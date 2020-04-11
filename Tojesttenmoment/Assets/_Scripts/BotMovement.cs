using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public GameObject ball;
    public float xDetection, standardY, standardX;
    private Vector3 desiredPosition;
    private float smoothSpeed, smoothRotSpeed;
    Quaternion desiredRotation;

    private void Start()
    {
        standardY = transform.position.y;
    }

    void FixedUpdate()
    {
        if (ball.transform.position.x <= xDetection && ball.GetComponent<Rigidbody>().velocity.x<0f)
        {
            desiredPosition = new Vector3(standardX, ball.transform.position.y, ball.transform.position.z);
            //LIMITER
            if (desiredPosition.y < 2.5f)
                desiredPosition.y = 2.5f;
            else if (desiredPosition.z < -13f)
                desiredPosition.z = -13f;
            else if (desiredPosition.z > 13f)
                desiredPosition.z = 13f;


            smoothSpeed = 0.2f;
        }
        else
        {
            if (ball.transform.position.x > xDetection*2f)
                desiredPosition = new Vector3(standardX, standardY, 0f);
            smoothSpeed = 0.03f;
        }
        smoothRotSpeed = 0.1f;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
     
        transform.position = smoothedPosition;




        if (-90f + transform.position.z * 10 > 0f || -90f + transform.position.z * 10 < -180f)
        {
            if (-90f + transform.position.z * 10 > 0f)
                desiredRotation = Quaternion.Euler(0f, transform.rotation.y, -90f);
            else if (-90f + transform.position.z * 10 < -180f)
                desiredRotation = Quaternion.Euler(-180f, transform.rotation.y, -90f);
        }
        else desiredRotation = Quaternion.Euler(-90f + transform.position.z * 10, transform.rotation.y, -90f);


        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothRotSpeed);
    }
}
