using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phonecam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetAxis("Vertical") > 0 && GetComponent<Camera>().fieldOfView > 5)
		{
			GetComponent<Camera>().fieldOfView -= Input.GetAxis("Vertical");
		}
		if (Input.GetAxis("Vertical") < 0 && GetComponent<Camera>().fieldOfView < 60)
		{
			GetComponent<Camera>().fieldOfView -= Input.GetAxis("Vertical");
		}

	}
}
