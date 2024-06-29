using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonAlpha : MonoBehaviour
{

    public void ChangeAlpha(float alpha)
    {
        Color temp = GetComponent<Image>().color;
        temp.a = alpha;
        GetComponent<Image>().color = temp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
