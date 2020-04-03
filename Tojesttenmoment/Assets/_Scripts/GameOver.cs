using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI, winGlasses;

    public void over()
    {
        StartCoroutine(Order());
    }
    

    IEnumerator Order()
    {
        winGlasses.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        Debug.Log("MENU!");
        SceneManager.LoadScene("Menu");
    }
}
