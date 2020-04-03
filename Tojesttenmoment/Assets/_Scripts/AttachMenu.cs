using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachMenu : MonoBehaviour
{
    public Image branch;
    public Vector3 offset;

    void Update()
    {
        Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position+offset);
        branch.transform.position = namePose;
    }
}
