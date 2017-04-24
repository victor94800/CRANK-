using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
	public Transform Lookat;
	public Transform target;
	
	public Transform camTransform;

	private Camera cam;

	public float distance;
	public float follow_speed;

	public Vector3 dirtomain;
	// Use this for initialization
	void Start()
	{
		camTransform = transform;
		cam = Camera.main;


	}
	private void LateUpdate()
	{
			//Lookat = GameObject.Find("playerlookat").transform;
		    //target = GameObject.Find("player").transform;
		dirtomain = Lookat.transform.position - transform.position;
		
			Vector3 dir = new Vector3(0, -1, -distance);
			Quaternion rotation = Quaternion.Euler(0, 0, 0);
			camTransform.position = target.position + rotation * dir;
		//camTransform.LookAt(Lookat.position);
		if (target.GetComponent<CharacterController>().isGrounded)
		{
			//camTransform.LookAt(Lookat.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), follow_speed);
		}

	}

	// Update is called once per frame
	
}
