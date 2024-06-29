using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulation : MonoBehaviour
{
    public GameObject UI;
    public List<Material> Materials;
    int initMaterialPos = 0;
    int initObjectPos = 0;

    //public GameObject rotateObj;
    public float rotateSpeed = 1f;
    float tempAngle = 0f;
    bool startRotate = false;

    //public GameObject scaleObj;
    public float scaleSpeed = 0.05f;
    bool startScale = false;
    Vector3 scaleChange = Vector3.zero;

    //public GameObject changeTextureObj;
    public GameObject ObjToManipulate;

    public List<GameObject> changeObjs;

    public void ChangeNextObject()
    {
        changeObjs[initObjectPos].SetActive(false);
        initObjectPos++;
        if (initObjectPos == changeObjs.Count)
            initObjectPos = 0;
        ObjToManipulate = changeObjs[initObjectPos];
        ObjToManipulate.SetActive(true);
    }

    public void ChangeObjectIndex(int index)
    {
        changeObjs[initObjectPos].SetActive(false);
        initObjectPos = index;
        ObjToManipulate = changeObjs[initObjectPos];
        ObjToManipulate.SetActive(true);
    }

    public void ChangeMaterialIndex(int index)
    {
        initMaterialPos = index;
        ObjToManipulate.GetComponent<MeshRenderer>().material = Materials[initMaterialPos];
    }

    public void RemoveObject(GameObject obj)
    {
        GameObject.Destroy(obj);
    }

    public void RotateObject(bool rotate)
    {
        startRotate = rotate;
    }

    public void ScaleUpObject(bool scale)
    {
        startScale = scale;
        scaleSpeed = Mathf.Abs(scaleSpeed);
    }

    public void ScaleDownObject(bool scale)
    {
        startScale = scale;
        scaleSpeed = Mathf.Abs(scaleSpeed) * (-1);
    }

    public void ChangePreviousMaterial()
    {
        initMaterialPos--;
        if (initMaterialPos == -1)
            initMaterialPos = Materials.Count - 1;
        ObjToManipulate.GetComponent<MeshRenderer>().material = Materials[initMaterialPos];
    }

    public void ChangeNextMaterial()
    {
        initMaterialPos++;
        if (initMaterialPos == Materials.Count)
            initMaterialPos = 0;
        ObjToManipulate.GetComponent<MeshRenderer>().material = Materials[initMaterialPos];
    }

    public GameObject buttonOn;
    public void ResetAllUI()
    {
        foreach (GameObject informationcanvas in GameObject.FindGameObjectsWithTag("InformationCanvas"))
        {
            informationcanvas.SetActive(false);
        }
        foreach (GameObject detectcanvas in GameObject.FindGameObjectsWithTag("DetectCanvas"))
        {
            detectcanvas.transform.GetChild(0).gameObject.SetActive(true);
        }
        buttonOn.SetActive(false);
    }

    void Start()
    {
        scaleChange = ObjToManipulate.transform.localScale;
    }

    public void TriggerUI(GameObject ui)
    {
        UI = ui;
        if (UI.activeSelf)
        {
            UI.SetActive(false);
            //UI.GetComponent<InterfaceAnimManager>().startDisappear(true);
        }
        else UI.SetActive(true);
    }
    void Update()
    {
        /*var fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
        if (fingerCount == 1)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.gameObject.Equals(scaleObj))
                {
                    if (UI.activeSelf)
                    {
                        UI.SetActive(false);
                        //UI.GetComponent<InterfaceAnimManager>().startDisappear(true);
                    }
                    else UI.SetActive(true);
                }
            }
            //print("User has " + fingerCount + " finger(s) touching the screen");
        }*/
        if (startRotate)
        {
            ObjToManipulate.transform.Rotate(Vector3.up, rotateSpeed);
        }

        if(startScale)
        {
            scaleChange.x = ObjToManipulate.transform.localScale.x + scaleSpeed;
            scaleChange.y = ObjToManipulate.transform.localScale.y + scaleSpeed;
            scaleChange.z = ObjToManipulate.transform.localScale.z + scaleSpeed;
            ObjToManipulate.transform.localScale = scaleChange;
        }
    }
}
