using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickControllerCam : MonoBehaviour
{
    public GameObject camController;
    public Joystick joystick;
    public bool isMove = true;
    Vector3 movement;
    Vector3 tforward;
    public float joyStickSpeed = 1;
    //Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        movement = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isMove)
        //{
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward) * joyStickSpeed * joystick.Vertical;
            Vector3 right = transform.TransformDirection(Vector3.right) * joyStickSpeed * joystick.Horizontal;
            forward.y = 0;
            right.y = 0;
            if (isMove) camController.transform.Translate(forward + right, Space.World);
            else
            {
                if (camController.GetComponent<WallBlockMove>().direction.x == -1)
                {
                    if ((camController.transform.position + forward + right).x < camController.GetComponent<WallBlockMove>().collisionObject.transform.position.x)
                        camController.transform.Translate(forward + right, Space.World);
                }
                if (camController.GetComponent<WallBlockMove>().direction.x == 1)
                {
                    if ((camController.transform.position + forward + right).x > camController.GetComponent<WallBlockMove>().collisionObject.transform.position.x)
                        camController.transform.Translate(forward + right, Space.World);
                }
                if (camController.GetComponent<WallBlockMove>().direction.y == -1)
                {
                    Debug.Log("Cam z: " + (camController.transform.position + forward + right).z);
                    Debug.Log("Wall z: " + (camController.GetComponent<WallBlockMove>().collisionObject.transform.position.z));
                    if ((camController.transform.position + forward + right).z > camController.GetComponent<WallBlockMove>().collisionObject.transform.position.z)
                        camController.transform.Translate(forward + right, Space.World);
                    else Debug.Log("Stop");
                }
                if (camController.GetComponent<WallBlockMove>().direction.y == 1)
                {
                    if ((camController.transform.position + forward + right).z < camController.GetComponent<WallBlockMove>().collisionObject.transform.position.z)
                        camController.transform.Translate(forward + right, Space.World);
                }
                //if ((camController.transform.position + forward + right).x > camController.GetComponent<WallBlockMove>().collisionObject.transform.position.x
                //    && (camController.transform.position + forward + right).z <= camController.GetComponent<WallBlockMove>().collisionObject.transform.position.z)
                //if ((camController.transform.position + forward + right).z > camController.GetComponent<WallBlockMove>().collisionObject.transform.position.z)
                //camController.transform.Translate(forward + right, Space.World);
            }
        }
        //}
    }
}
