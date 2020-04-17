using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorBehav : MonoBehaviour
{

    private Color color;
    private string[] defColors = {"yellow", "lime"}; //{"red", "blue", "darkblue", "lightblue", "purple", "yellow", "lime", "fuchsia", "orange", "brown", "maroon", "green", "navy", "teal", "magenta"};

    private void Start()
    {
        while(true) {
            int i;
            if (gameObject.tag != "Bot") 
                i = Random.Range(0, defColors.Length);
            else i = 0;
            if (ColorUtility.TryParseHtmlString(defColors[i], out color))
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
                break;
            }
            else Debug.Log(defColors[i]);     
        }
    }
}
