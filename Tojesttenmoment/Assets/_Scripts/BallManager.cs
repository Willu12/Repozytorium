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

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            rb.velocity = Vector3.zero;
            
            rb.AddForce(new Vector3(1.5f*change, -0.3f, 0f));

            //BALANCER
            float posz = transform.position.z;
            if (posz<1.5f && posz>-1.5f)
                zbalancer(-0.35f, 0.35f);
            else if (posz<-1.5f && posz>-3f)
                zbalancer(0f, 0.4f);
            else if (posz>1.5f && posz<3f)
                zbalancer(-0.4f, 0f);
            else if (posz<-3f)
                zbalancer(0.1f, 0.5f);
            else if (posz>3f)
                zbalancer(-0.1f, -0.5f);
            
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

    private void zbalancer(float rfrom, float rto)
    {
        rb.AddForce(new Vector3(0f, 0f, Random.Range(rfrom, rto)));
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
            rb.AddForce(new Vector3(-1.5f*change, -0.3f, 0));

            //Z BALANCER
            float posz = transform.position.z;
            if (posz<1.5f && posz>-1.5f)
                zbalancer(-0.35f, 0.35f);
            else if (posz<-1.5f && posz>-3f)
                zbalancer(0f, 0.4f);
            else if (posz>1.5f && posz<3f)
                zbalancer(-0.4f, 0f);
            else if (posz<-3f)
                zbalancer(0.1f, 0.5f);
            else if (posz>3f)
                zbalancer(-0.1f, -0.5f);
            
            ally.SetActive(false);
            hit = false;
        }
    }
}
