using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlockMove : MonoBehaviour
{
    public GameObject cam;
    public GameObject collisionObject;
    //Vector for direction
    // 1  0: right
    // -1 0: left
    // 0  1: up
    // 0 -1: down
    public Vector2 direction = new Vector2(0, 0); //x - z

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision occur");
        if (other.gameObject.tag.Equals("Wall"))
        {
            cam.GetComponent<JoyStickControllerCam>().isMove = false;
            collisionObject = other.gameObject;
            direction = other.gameObject.GetComponent<WallDirection>().dir;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Wall"))
            cam.GetComponent<JoyStickControllerCam>().isMove = true;
    }

}
