using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BallManager : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    TextMeshProUGUI scoreText, bestText;

    public AudioClip hit1;
    public AudioClip impact1, impact2, impact3;
    public AudioClip recordBeaten;

    public GameObject table, stmp, btmp;
    
    public TrailRenderer tr;
    public GameObject Canvas;
    public GameObject Tutorial;

    public float zForce;

    public float progresStep = 0.02f;

    bool once = false;
    bool tablecheck = true;

    bool playerAccelerometer = true;

    Vector3 hitforce;

    int points = 0;
    int best;

    void Start()
    {
        Time.timeScale = 1f;
        hitforce = new Vector3(-15f, 3f, 0f);
        best = PlayerPrefs.GetInt("BestScore", 0);

        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        scoreText = stmp.GetComponent<TextMeshProUGUI>();
        bestText = btmp.GetComponent<TextMeshProUGUI>();

        scoreText.text = points.ToString();
        if(best!=0) {
            btmp.SetActive(true);
            bestText.text = best.ToString();
        } else {
            btmp.SetActive(false);
        }

        Physics.gravity = new Vector3(0f, -10f, 0f);
        //rb.angularVelocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f)*10;
        rb.useGravity = false;      
    }

    private void PlaySound(string type)
    {
        if(type == "hit")
        {
           audioSource.PlayOneShot(hit1);
        } else if(type == "impact")
        {
            int i = Random.Range(1, 4);
            if (i == 1)
            {
                audioSource.PlayOneShot(impact1);
            } else
            if (i == 2)
            {
                audioSource.PlayOneShot(impact2);
            } else
            if (i == 3)
            { 
                audioSource.PlayOneShot(impact3);
            }
        }
        return;
    }

    private void Update()
    {
        if (transform.position.x > GameObject.FindWithTag("MainCamera").transform.position.x + 1f && !once)
            End();
        Vector3 tilt = Input.acceleration;
        if ((tilt.x >= 0.15f || tilt.x <= -0.15f) && !tablecheck && playerAccelerometer)
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, 20 * tilt.x);
        else Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, 0f);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Table")
        {
            Debug.Log("Collided Table");
            PlaySound("impact");
            tablecheck = true;              
        }
        if (col.gameObject.tag == "Bot")
        {
            Debug.Log("Collided Bot");
            PlaySound("hit");
            //tr.Clear();

            bforce();

            //Z BALANCER
            float posz = transform.position.z;
            if (posz<=1.5f && posz>=-1.5f)
                zbalancer(-0.35f, 0.35f);
            else if (posz<=-1.5f && posz>=-3f)
                zbalancer(0f, 0.4f);
            else if (posz>=1.5f && posz<=3f)
                zbalancer(-0.4f, 0f);
            else if (posz<=-3f)
                zbalancer(0.1f, 0.5f);
            else if (posz>=3f)
                zbalancer(-0.1f, -0.5f);

            playerAccelerometer = false;
        } 
        if (col.gameObject.tag == "Floor" && !once)
        {
            End();
        }
    }

    void End()
    {
        Debug.Log("Collided Floor");
        Time.timeScale = 1f;
        once = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
        Canvas.GetComponent<GameOver>().over();
    }

    private void zbalancer(float rfrom, float rto)
    {
        zForce = Random.Range(rfrom, rto);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, zForce*12);
    }

    public void OnMouseDown()
    {
        Debug.Log("Mouse Clicked");
        if (transform.position.x > 8f && tablecheck && !once && Tutorial.activeSelf == false) //!once is just for disabling movement while animating
        {
            PlaySound("hit");
            //tr.Clear();
            if (rb.useGravity == true)
            {
                points++;
                scoreText.text = points.ToString();
                if(points>best) {
                    if (best!=0 && points == best+1)
                        audioSource.PlayOneShot(recordBeaten);
                    PlayerPrefs.SetInt("BestScore", points);
                    btmp.SetActive(false);
                    scoreText.color = new Color32(166, 254, 0, 255);
                }
            }
            else rb.useGravity = true;

            hforce();

            //Z BALANCER
            float posz = transform.position.z;
            if (posz<=1.5f && posz>=-1.5f)
                zbalancer(-0.35f, 0.35f);
            else if (posz<=-1.5f && posz>=-3f)
                zbalancer(0f, 0.4f);
            else if (posz>=1.5f && posz<=3f)
                zbalancer(-0.4f, 0f);
            else if (posz<=-3f)
                zbalancer(0.1f, 0.5f);
            else if (posz>=3f)
                zbalancer(-0.1f, -0.5f);

            playerAccelerometer = true;
        }
    }


    void bforce()
    {
        Time.timeScale += progresStep;
        float diffx = 0f, diffy = 0f;
        if (rb.transform.position.x < -10f)
        {
            diffx = -10f - rb.transform.position.x;
        }
        if (rb.transform.position.y < 3f)
            diffy = 3f - rb.transform.position.y;
        rb.velocity = Vector3.zero;
        float customY = Random.Range(0f, 1.5f);
        rb.velocity = new Vector3(-1f*(hitforce.x - (0.5f * diffx) + (Random.Range(1.3f, 2f) * customY)), hitforce.y + (0.7f * diffy) + customY, 0f);
        tablecheck = false;
    }

    void hforce()
    {
        float diffx = 0f, diffy = 0f;
        if (rb.transform.position.x > 10f)
        {
            diffx = 10f - rb.transform.position.x;
        }
        if (rb.transform.position.y < 3f)
            diffy = 3f - rb.transform.position.y;
        rb.velocity = Vector3.zero;
        float customY = Random.Range(0f, 1.5f);
        rb.velocity = new Vector3(hitforce.x+(0.5f * diffx)+(Random.Range(1.3f, 2f) * customY), hitforce.y+(0.7f*diffy)+customY, 0f);
        tablecheck = false;
    }

}