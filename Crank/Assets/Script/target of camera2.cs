using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetofcamera2 : MonoBehaviour {

	// Use this for initialization
	public GameObject camera;
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(new Vector3(0, Input.GetAxis("Vertical2"), 0));
		transform.RotateAround(camera.transform.position, Vector3.up, Input.GetAxis("Horizontal") * 100 * Time.deltaTime);
	}
}
