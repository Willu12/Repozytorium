using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    void Awake()
    {
        int seen = PlayerPrefs.GetInt("SeenTut", 0);
        if (seen == 1)
            gameObject.SetActive(false);
    }

    public void Accept() 
    {
        PlayerPrefs.SetInt("SeenTut", 1);
        gameObject.SetActive(false);
    }
}
