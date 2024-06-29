using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSampleObject : MonoBehaviour
{
    public GameObject sample;
    public float angle = 1f;
    bool isLeft = true;
    bool startRotate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startRotate)
        {
            if (isLeft)
                sample.transform.Rotate(Vector3.up, angle);
            else
                sample.transform.Rotate(Vector3.up, -angle);
        }
        
    }

    public void RotateObject(bool rotate)
    {
        startRotate = rotate;
    }
    public void RotateLeft(bool left)
    {
        isLeft = left;
    }
}
