﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public TextMeshProUGUI best;

    private void Start()
    {
        int bscore = PlayerPrefs.GetInt("BestScore", 0);
        best.text = bscore.ToString();
    }


    public void OnMouseDown()
    {
        SceneManager.LoadScene("Game");
    }

    public void Credits()
    {
        Debug.Log("CREDITS!");
    }

    public void Settings()
    {
        Debug.Log("SETTINGS!");
    }

    public void Shop()
    {
        Debug.Log("SHOP!");
    }
}
