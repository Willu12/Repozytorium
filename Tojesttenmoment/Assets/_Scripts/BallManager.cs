using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class BallManager : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    AudioSource audioSource;
    public AudioClip hit1, hit2, hit3, hit4;
    public AudioClip impact1, impact2, impact3, impact4;
    bool hit,sound;
    public GameObject enemy, ally, table, stmp, btmp;
    private TextMeshProUGUI scoreText, bestText;
    public TrailRenderer tr;
    public GameObject Canvas;
    public float change = 1f;
    public Color[] starttrails;
    public Color[] endtrails;

    int points=0, best, trailindex;
    void Start()
    {
        trailindex = PlayerPrefs.GetInt("trailindex", 0);
        best = PlayerPrefs.GetInt("BestScore", 0);
        hit = false;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        scoreText = stmp.GetComponent<TextMeshProUGUI>();
        bestText = btmp.GetComponent<TextMeshProUGUI>();
        scoreText.text = points.ToString();
        Debug.Log(best.ToString());
        if(best!=0) {
            btmp.SetActive(true);
            bestText.text = best.ToString();
        } else {
            btmp.SetActive(false);
        }

        change = 1f;
        Physics.gravity = new Vector3(0f, -9.8f, 0f);
        rb.angularVelocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f)*10;
        rb.useGravity = false;
        Colortrail();
    }

    private void Colortrail()
    {
        tr.startColor = starttrails[trailindex];
        tr.endColor = endtrails[trailindex];
    }

    private void PlaySound(string type)
    {
        int i = Random.Range(1, 5);
        if(type == "hit")
        {
            if (i == 1)
            {
                audioSource.PlayOneShot(hit1);
            } else
            if (i == 2)
            {
                audioSource.PlayOneShot(hit2);
            } else
            if (i == 3)
            {
                audioSource.PlayOneShot(hit3);
            } else
            if (i == 4)
            {
                audioSource.PlayOneShot(hit4);
            }
        } else
        if(type == "impact")
        {
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
            } else
            if (i == 4)
            {
                audioSource.PlayOneShot(impact4);
            }
        }
        return;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Table")
        {
            if(sound)
            {
                PlaySound("impact");
                sound = false;
            }
            
        }
        if (col.gameObject.tag == "Wall")
        {
            PlaySound("hit");
            tr.Clear();
            sound = true;


            rb.velocity = Vector3.zero;
            
            rb.AddForce(new Vector3(1.5f*change, Random.Range(-1.2f, -0.3f), 0f));

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
            
            Physics.gravity = new Vector3(0f, -9.8f-change, 0f);
            change += 0.025f;
            hit = false;
            ally.SetActive(true);
        } 
        if (col.gameObject.tag == "Player")
        {
            hit = true;
            ally.SetActive(false);
            enemy.SetActive(true);        
        }
        if (col.gameObject.tag == "Floor")
        {
            Canvas.GetComponent<GameOver>().over();
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
            PlaySound("hit");
            tr.Clear();
            sound = true;
            if (rb.useGravity == true)
            {
                points++;
                scoreText.text = points.ToString();
                if(points>best) {
                    PlayerPrefs.SetInt("BestScore", points);
                    btmp.SetActive(false);
                    scoreText.color = new Color32(166, 254, 0, 255);
                }
            }
            rb.useGravity = true;

            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(-1.5f*change, Random.Range(-1.2f, -0.3f), 0));

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
