using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetUI : MonoBehaviour
{
    public GameObject[] UIs;
    public void ResetAllUI()
    {
        foreach (GameObject ui in UIs)
        {
            ui.SetActive(false);
        }
    }
}
