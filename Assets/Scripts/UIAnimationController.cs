using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationController : MonoBehaviour
{
    public Vector3 changePosition;
    public GameObject StageAnchor;
    public GameObject HouseUI;
    public GameObject House;
    public GameObject Park;
    public GameObject ParkUI;
    public float translateSpeed = 1;

    float tempSpeed = 0;
    bool isTranslate = false;
    Vector3 currentPosition;
    public void StartTranslate()
    {
        isTranslate = true;
    }

    public void StopAnimation()
    {
        GetComponent<Animator>().enabled = false;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        changePosition = changePosition + StageAnchor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTranslate)
        {
            tempSpeed += 0.01f * translateSpeed;
            transform.position = Vector3.Lerp(currentPosition, changePosition, tempSpeed);
            if (transform.position.Equals(changePosition))
            {
                isTranslate = false;
                StartCoroutine("WaitTime");
                HouseUI.SetActive(true);
                //MainUI.GetComponent<InterfaceAnimManager>().startAppear();
                House.SetActive(true);
                Park.SetActive(true);
                ParkUI.SetActive(true);
            }
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1);
    }

}
