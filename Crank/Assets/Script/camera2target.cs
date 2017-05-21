using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2target : MonoBehaviour {

	// Use this for initialization
	public GameObject Camera;
	public float rotatespeed1;
	public float 	rotatespeed2;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("Vertical2") == 1 || Input.GetAxis("Vertical2") == -1)
		{
			transform.Translate(new Vector3(0, -Input.GetAxis("Vertical2") * rotatespeed1, 0));
		}
		if (Input.GetAxis("Horizontal2") == 1 || Input.GetAxis("Horizontal2") == -1)
		transform.RotateAround(Camera.transform.position, Vector3.up, -Input.GetAxis("Horizontal2") * rotatespeed2 * Time.deltaTime);
	}
}
