using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlokkatandfollow : MonoBehaviour {
	private Transform Target;
	public GameObject target;
	Vector3 dirtomain;
	void Start()
	{
		Target = target.transform;
	}

	// Update is called once per frame
	void Update()
	{
		dirtomain = target.transform.position - transform.position;
		if (Target.transform.position != transform.position)
		{
			transform.position = Target.transform.position;
			
		}
		if (target.GetComponent<CharacterController>().isGrounded)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 0.1f);
			//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 10f);
		}
	}
}
