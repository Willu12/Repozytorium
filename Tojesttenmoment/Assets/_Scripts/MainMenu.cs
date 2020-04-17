using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public TextMeshProUGUI best;
    public Animator CamAnim, uianim, logoanim;


    private void Start()
    {
        int bscore = PlayerPrefs.GetInt("BestScore", 0);
        best.text = bscore.ToString();
    }


    IEnumerator anim()
    {
        uianim.SetTrigger("SceneChange");
        logoanim.SetTrigger("LogoOut");
        yield return new WaitForSeconds(0.5f);
        CamAnim.enabled = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
    }


    public void OnMouseDown()
    {
        StartCoroutine(anim());
    }

    public void Credits()
    {
        Debug.Log("CREDITS!");
    }

    public void Settings()
    {
        PlayerPrefs.SetInt("SeenTut", 0);
        Debug.Log("SETTINGS!");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
}
