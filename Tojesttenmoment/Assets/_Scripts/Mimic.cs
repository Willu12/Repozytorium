using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{
    public GameObject source;
    public bool x, y, z;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (x == true)
            transform.position = new Vector3(source.transform.position.x, transform.position.y, transform.position.z);
        if (y == true)
            transform.position = new Vector3(transform.position.x, source.transform.position.y, transform.position.z);
        if (z == true)
            transform.position = new Vector3(transform.position.x, transform.position.y, source.transform.position.z);
    }
}
