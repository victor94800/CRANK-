using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phonecamera : MonoBehaviour {
	public Vector3 dirtomain;
	public Transform Lookat;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		dirtomain = Lookat.transform.position - transform.position;
		/*if (Input.GetAxis("Vertical2") == 1 || Input.GetAxis("Vertical2") == -1)
		{
			transform.Rotate(new Vector3(Input.GetAxis("Vertical2"), 0, 0));
		}
		if (Input.GetAxis("Horizontal2") == 1|| Input.GetAxis("Horizontal2") == -1)
		{
			
			transform.Rotate(new Vector3(0, -Input.GetAxis("Horizontal2"), 0));
		}*/


		if (Input.GetAxis("Vertical") > 0 && GetComponent<Camera>().fieldOfView > 5)
		{
			GetComponent<Camera>().fieldOfView -= Input.GetAxis("Vertical");
		}
		if (Input.GetAxis("Vertical") < 0 && GetComponent<Camera>().fieldOfView < 60)
		{
			GetComponent<Camera>().fieldOfView -= Input.GetAxis("Vertical");
		}
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 10);

	}
}
