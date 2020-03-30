using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody r;
    bool hit;
    public GameObject enemy, ally;
    float boost = 1f, slow=1f;
    void Start()
    {
        hit = false;
        r = GetComponent<Rigidbody>();
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
            r.AddForce(new Vector3(0.7f*boost,0.3f*slow,0));
            boost += 0.6f;
            slow -= 0.2f;
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
            r.AddForce(new Vector3(-0.7f*boost, 0.3f*slow, 0));
            boost += 0.6f;
            slow -= 0.05f;
        }
    }

}
