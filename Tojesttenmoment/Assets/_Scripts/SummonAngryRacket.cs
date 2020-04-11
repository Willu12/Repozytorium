using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAngryRacket : MonoBehaviour
{
    public Vector3 pos;
    public MeshRenderer a, b, c;
    public GameObject ball, canvas;

    Quaternion desiredRotation;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && ball.transform.position.x >= 0f && !canvas.GetComponent<GameOver>().fin)
        {
            StopCoroutine(ShowForMoment());
            // create ray from the camera and passing through the touch position:
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            // create a logical plane at this object's position
            // and perpendicular to world Y:
            Plane plane = new Plane(Vector3.up, transform.position);
            float distance = 0; // this will return the distance from the camera
            if (plane.Raycast(ray, out distance))
            { // if plane hit...
                pos = ray.GetPoint(distance); // get the point
                Debug.DrawLine(Vector3.zero, pos, new Color32(255, 0, 0, 255), 3f); // pos has the position in the plane you've touched

                StartCoroutine(ShowForMoment());
            }
        }    
    }

    IEnumerator ShowForMoment()
    {
        transform.position = pos;
        SetRotation();
        a.enabled = true;
        b.enabled = true;
        c.enabled = true;
        yield return new WaitUntil(() => Input.touchCount == 0f || canvas.GetComponent<GameOver>().fin == true);
        a.enabled = false;
        b.enabled = false;
        c.enabled = false;

    }

    void SetRotation()
    {
        if (-90f + transform.position.z * 10 > 0f || -90f + transform.position.z * 10 < -180f)
        {
            if (-90f + transform.position.z * 10 > 0f)
                desiredRotation = Quaternion.Euler(0f, transform.rotation.y, -90f);
            else if (-90f + transform.position.z * 10 < -180f)
                desiredRotation = Quaternion.Euler(-180f, transform.rotation.y, -90f);
        }
        else desiredRotation = Quaternion.Euler(-90f + transform.position.z * 10, transform.rotation.y, -90f);

        transform.rotation = desiredRotation;
    }
}
