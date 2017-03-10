using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		//speed = 10f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // fait tourner l'ojet vers l'avant en continu 
        transform.Rotate(speed * 1, 0, 0);

    }
}
