using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public float speed = 50F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0); //rotates 50 degrees per second around z axis
    }
}
