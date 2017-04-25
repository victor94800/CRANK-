using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersoncamera : MonoBehaviour {
	public Transform Lookat;
	public Transform target;
	public Transform camTransform;

	private float currentX = 0f;
	private float currentY = 0f;
	private Transform tamera;
	
	private Camera cam;

	public float distance;

	public Vector3 dirtomain;
	// Use this for initialization
	void Start ()
	{
		camTransform = transform;
		cam = Camera.main;

		
	}
	private void LateUpdate()
	{
		dirtomain = Lookat.transform.position - transform.position;
		if (dirtomain.magnitude > distance || dirtomain.magnitude < distance -2)
		{
			Vector3 dir = new Vector3(0, 0, -distance);
			Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
			camTransform.position = target.position + rotation * dir;
			camTransform.LookAt(Lookat.position);
		}
		camTransform.LookAt(Lookat.position);
	}

	// Update is called once per frame
	void Update ()
	{
		
		currentY = Input.GetAxis("Horizontal2");
		target.rotation  = Quaternion.Euler(currentX, currentY, 0);
		

	}






}
