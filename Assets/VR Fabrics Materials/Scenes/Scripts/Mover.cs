using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed = 50F;
    public float end_line = -36F;
    public float decay_factor = 0.01F;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (speed == 0) return;

        if(transform.position.z < end_line)
        {
            speed -= decay_factor;
        }

        if (speed < 0) speed = 0;

        transform.Translate(0, 0, speed * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
