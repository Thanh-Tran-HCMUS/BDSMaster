using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour
{
    public float speed = 0.1f;
    Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            currentPos.z -= speed;
        if (Input.GetKey(KeyCode.D))
            currentPos.z += speed;
        if (Input.GetKey(KeyCode.W))
            currentPos.x += speed;
        if (Input.GetKey(KeyCode.S))
            currentPos.x -= speed;
        transform.position = currentPos;

    }
}
