using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{
    public GameObject source;
    public bool x, y, z;

    private Vector3 desiredPosition;

    private bool finish;

    private void Start()
    {
        desiredPosition = new Vector3(transform.position.x, transform.position.y, 0f);
    }




    // Update is called once per frame
    void Update()
    {
        finish = GameObject.Find("/Canvas").GetComponent<GameOver>().fin;
        if (!finish)
        {
            if (x == true)
                transform.position = new Vector3(source.transform.position.x, transform.position.y, transform.position.z);
            if (y == true)
                transform.position = new Vector3(transform.position.x, source.transform.position.y, transform.position.z);
            if (z == true)
                transform.position = new Vector3(transform.position.x, transform.position.y, source.transform.position.z);
        }
        else
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.025f);
            transform.position = smoothedPosition;
        }
    }
}
