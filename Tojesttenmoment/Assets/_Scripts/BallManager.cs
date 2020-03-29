using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody r;
    public bool hit = false;
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hit);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            r.AddForce(new Vector3(0.7f,0.3f,0));
            hit = false;
        }
        if(col.gameObject.tag == "Player")
        {
             hit = true;
        }
       
    }
    private void OnMouseDown()
    {
        if (hit)
        {
            r.AddForce(new Vector3(-0.7f, 0.3f, 0));
        }    
    }
}
