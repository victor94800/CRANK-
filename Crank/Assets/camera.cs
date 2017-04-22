using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
	private Transform Target;
	public GameObject target;
	Vector3 dirtomain;
	// Use this for initialization
	void Start()
	{
		Target = target.transform;
	}

	// Update is called once per frame
	void Update()
	{
		//dirtomain = GameObject.Find("Target").transform.position - transform.position;
	/*	if (Target.transform.position != transform.position)
		{
			transform.position = Target.transform.position;
			transform.rotation = Target.transform.rotation;
		}*/
		if (Input.GetAxis("Horizontal2") > 0)
		{
			transform.Rotate(0, Input.GetAxis("Horizontal2"), 0);
		}
		//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 10f);

	}
}