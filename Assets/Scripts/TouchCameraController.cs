using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCameraController : MonoBehaviour
{
    //public Joystick joystick;
    //Vector3 movement;
    //public float joyStickSpeed = 1;
    public bool isMove = false;
    public float touchSpeed = 1f;

    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;

    public void SetMoving(bool move)
    {
        isMove = move;
    }

    // Start is called before the first frame update
    void Start()
    {
        //joystick = FindObjectOfType<Joystick>();
        //movement = transform.position;

        xAngle = 0;
        yAngle = 0;
        transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
       // movement.x += joystick.Horizontal * joyStickSpeed;
        //movement.z += joystick.Vertical * joyStickSpeed;
        //transform.position = movement;

        if (isMove)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    FirstPoint = Input.GetTouch(0).position;
                    xAngleTemp = xAngle;
                    yAngleTemp = yAngle;
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    SecondPoint = Input.GetTouch(0).position;
                    xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                    yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                    this.transform.rotation = Quaternion.Euler(yAngle * touchSpeed, xAngle * touchSpeed, 0.0f);
                }
            }
        }
    }
}
