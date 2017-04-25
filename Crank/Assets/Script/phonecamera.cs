using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phonecamera : MonoBehaviour {
	public Vector3 dirtomain;
	public Transform Lookat;
	public GameObject target_p;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (target_p == null)
		{
			dirtomain = Lookat.transform.position - transform.position;



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
		else
		{
			dirtomain = target_p.transform.position - transform.position;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 10);
		}
	}
}
