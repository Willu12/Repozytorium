using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    bool hit;
    public GameObject enemy, ally;
    float boost = 1f, slow=1f;
    void Start()
    {
        hit = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(hit);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(1.5f*boost,-0.3f*slow,Random.Range(-0.1f, +0.1f)));
            boost += 0.025f;
            slow += 0.025f;
            hit = false;
            ally.SetActive(true);
            enemy.SetActive(false);
        }
        if (col.gameObject.tag == "Player")
        {
            hit = true;
            ally.SetActive(false);
            enemy.SetActive(true);        
        }
    }
    private void OnMouseDown()
    {
        if (hit)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(-1.5f*boost,-0.3f*slow, Random.Range(-0.1f, +0.1f)));
        }
    }

}
