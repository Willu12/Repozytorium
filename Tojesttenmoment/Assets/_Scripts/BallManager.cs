using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallManager : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    bool hit;
    public GameObject enemy, ally, tmp;
    private TextMeshProUGUI textMesH;
    float change = 1f;
    int points=0;
    void Start()
    {
        hit = false;
        rb = GetComponent<Rigidbody>();
        textMesH = tmp.GetComponent<TextMeshProUGUI>();
        textMesH.text = points.ToString();

        rb.angularVelocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f)*10;
        rb.useGravity = false;
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
            rb.AddForce(new Vector3(1.5f*change,-0.3f*change, Random.Range(-0.1f, +0.1f)));
            Physics.gravity = new Vector3(change, change, 1f);
            change += 0.025f;
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
            if(rb.useGravity == true)
            {
                points++;
                textMesH.text = points.ToString();
            }
            rb.useGravity = true;
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(-1.5f*change, -0.3f*change, Random.Range(-0.1f, +0.1f)));
            ally.SetActive(false);
        }
    }
}
