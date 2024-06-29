using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetPosition : MonoBehaviour
{
    public void SetPosition(GameObject obj)
    {
        transform.position = obj.transform.position;
        transform.rotation = obj.transform.rotation;
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
