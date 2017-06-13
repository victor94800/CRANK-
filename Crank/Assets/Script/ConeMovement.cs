using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeMovement : MonoBehaviour {
    public float height;
    public float speed;
    public float alt1;
    public float alt2;
    private bool up;
    private bool down;
	// Use this for initialization
	void Start ()
    {
        alt1 = transform.position.y;
        alt2 = alt1 + height;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (transform.position.y <= alt1)
        {
            up = true;
            down = false;
        }
        if (transform.position.y >= alt2)
        {
            up = false;
            down = true;
        }
        if (up)
            transform.Translate(0, 0, -speed * Time.deltaTime);
        if (down) 
            transform.Translate(0, 0, speed * Time.deltaTime);
	}
}
