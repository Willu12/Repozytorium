using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundtrack : MonoBehaviour
{
    public AudioClip intro, soundtrack;
    public GameObject audioState;
    public Image buttonTexture;
    public Sprite on, off;
    private AudioSource audioSource;
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            Destroy(audioState);
            return;
        }
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(audioState);
        StartCoroutine(queue());
    }

    IEnumerator queue()
    {
        if (PlayerPrefs.GetInt("Mute", 0) == 0)
        {
            audioSource.mute = true;
            buttonTexture.sprite = off;
        }
        else
        {
            audioSource.mute = false;
            buttonTexture.sprite = on;
        }
        audioSource.PlayOneShot(intro);
        yield return new WaitWhile(() => audioSource.isPlaying);
        audioSource.clip = soundtrack;
        audioSource.Play();
    }

    public void changeState()
    {
        int currentState = PlayerPrefs.GetInt("Mute", 0);
        if (currentState == 0)
        {
            audioSource.mute = false;
            buttonTexture.sprite = on;
            PlayerPrefs.SetInt("Mute", 1);
        } else
        {
            audioSource.mute = true;
            buttonTexture.sprite = off;
            PlayerPrefs.SetInt("Mute", 0);
        }
    }
    private void LateUpdate()
    {
        transform.position = GameObject.FindWithTag("MainCamera").transform.position;
    }



}
