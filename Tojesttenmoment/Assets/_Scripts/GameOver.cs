using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI, winGlasses, trail;
    public bool fin = false;
    public void over()
    {
        fin = true;
        StartCoroutine(Order());
    }
    

    IEnumerator Order()
    {
        winGlasses.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        GameOverUI.SetActive(true);
    }

    public void PlayAgain()
    {
        hide();
        StartCoroutine(CPlayAgain());
    }

    IEnumerator CPlayAgain()
    {
        trail.SetActive(false);
        GameObject.Find("/Ball").GetComponent<Transform>().transform.position = new Vector3(10f, 5f, 0f);
        GameObject.Find("/Ball").GetComponent<Animator>().enabled = true;
        this.GetComponent<Animator>().SetTrigger("disappear");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
    }

    IEnumerator CMenu()
    {
        GameObject.Find("/Main Camera").GetComponent<Animator>().enabled = true;
        this.GetComponent<Animator>().SetTrigger("disappear");
        yield return new WaitForSeconds(1f);
        trail.SetActive(false);
        GameObject.Find("/Ball").GetComponent<Transform>().transform.position = new Vector3(10f, 5f, 0f);
        GameObject.Find("/Ball").GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1f);
        Debug.Log("MENU!");
        SceneManager.LoadScene("Menu");

    }

    public void hide()
    {
        GameOverUI.GetComponent<Animator>().SetTrigger("PanelOut");
    }


    public void Menu()
    {
        hide();
        StartCoroutine(CMenu());
    }
}
