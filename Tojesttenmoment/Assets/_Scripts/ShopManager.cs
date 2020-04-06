using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopManager : MonoBehaviour
{
    public GameObject balls, trails, paddles;
    int mode =1;
    int trailindex;

    public bool[] isboughtball;
    public Toggle[] balltoggles;
    public GameObject[] ballbuttons1;
    public Color[] ballcolors;

    public bool[] isboughtpaddle;
    public Toggle[] paddletoggles;
    public GameObject[] paddlebuttons;
    public Color[] paddlecolors;


    public bool[] isboughttrail;
    public Toggle[] trailtoggles;
    public GameObject[] trailbuttons;
    public int[] Trailcolor;

    public Material materialball,materialpaddle;


    void Start()
    {  
        materialball.color = ballcolors[0];
        materialpaddle.color = paddlecolors[0];
        isboughttrail = PlayerPrefsX.GetBoolArray("isboughttrail");
        isboughtball = PlayerPrefsX.GetBoolArray("isboughtpaddle");
        isboughtpaddle = PlayerPrefsX.GetBoolArray("isboughtpaddle");

    }

    void Update()
    {
        Boughtballs();
        Boughtpaddles();
        Boughttrails();
    }

    private void Changemode()
    {
        if (mode == 1)
        {
            balls.SetActive(false);
            trails.SetActive(true);
            paddles.SetActive(false);
            for (int k = 0; k < balltoggles.Length; k++)
            {
                if (balltoggles[k].isOn == true)
                {
                    materialball.color = ballcolors[k];
                }

            }
        }
        if (mode == 2)
        {
            balls.SetActive(false);
            trails.SetActive(false);
            paddles.SetActive(true);
            for (int l = 0; l < paddletoggles.Length; l++)
            {
                if (paddletoggles[l].isOn == true)
                {
                    materialpaddle.color = paddlecolors[l];
                }
            }

        }
        if(mode==3)
        {
            balls.SetActive(true);
            trails.SetActive(false);
            paddles.SetActive(false);
            for (int p = 0; p < trailtoggles.Length; p++)
            {
                if (trailtoggles[p].isOn == true)
                {
                    trailindex = p;
                    PlayerPrefs.SetInt("trailindex", trailindex);
                }
            }
        }
    }
    public void Rightarrow()
    {
        mode++;
        if(mode == 4)
        {
            mode = 1;
        }
        Changemode();
        Debug.Log(mode);
    }
    public void Leftarrow()
    {

        mode--;
        if (mode == 0)
        {
            mode = 3;
        }
        Changemode();
        Debug.Log(mode);
    }
    private void Boughtballs()
    {
        for (int i = 0; i<balltoggles.Length; i++)
        {
            if(isboughtball[i]==true)
            {
                balltoggles[i].interactable= true;
                ballbuttons1[i].SetActive(false);
            }
        }
    }

    public void BuySkinBall(int position)
    {
        /*
        if(stars>150)//150 cena skina
        {
            stars -= 150;
            
        ballbuttons[position].enabled = false;
        isboughtball[position] = true;
        }
        */
        ballbuttons1[position].SetActive(false);
        isboughtball[position] = true;
        PlayerPrefsX.SetBoolArray("isboughtball", isboughtball);
    }

    private void Boughtpaddles()
    {
        for (int j = 0; j < paddletoggles.Length; j++)
        {
            if (isboughtpaddle[j] == true)
            {
                paddletoggles[j].interactable = true;
                paddlebuttons[j].SetActive(false);
            }
        }
    }
    public void Buyskinpaddle(int position)
    {
        /*
        if(stars>150)//150 cena skina
        {
            stars -= 150;
            
        ballbuttons[position].enabled = false;
        isboughtball[position] = true;
        }
        */
        paddlebuttons[position].SetActive(false);
        isboughtpaddle[position] = true;
        PlayerPrefsX.SetBoolArray("isboughtpaddle", isboughtpaddle);
    }
    public void Leaveshop()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("trailindex to" + trailindex);
    }

    private void Boughttrails()
    {
        for (int j = 0; j < trailtoggles.Length; j++)
        {
            if (isboughttrail[j] == true)
            {
                trailtoggles[j].interactable = true;
                trailbuttons[j].SetActive(false);
            }
        }
    }
    public void Buyskintrail(int position)
    {
        /*
        if(stars>150)//150 cena skina
        {
            stars -= 150;
            
        ballbuttons[position].enabled = false;
        isboughtball[position] = true;
        }
        */
        trailbuttons[position].SetActive(false);
        isboughttrail[position] = true;
        
        
        PlayerPrefsX.SetBoolArray("isboughttrail", isboughttrail);
    }

}

