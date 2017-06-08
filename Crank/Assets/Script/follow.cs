using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
	// cible
	public Transform Lookat;
	public Transform target;
	// game object
	public Transform camTransform;
    public GameObject water;
	
	// physique
	public float distance;
	public float follow_speed;

	public Vector3 dirtomain;
	public Quaternion late_rotation;
	public bool stoped;
	
	public bool Keep_last_moving_rotation;
	// Use this for initialization
	void Start()
	{

		camTransform = transform;
		


	}
	private void LateUpdate()
	{
			
		dirtomain = Lookat.transform.position - transform.position;
		
			Vector3 dir = new Vector3(0, -1, -distance);
			Quaternion rotation = Quaternion.Euler(0, 0, 0);
			camTransform.position = target.position + rotation * dir;
	if (water == null)
		{
			if (target.GetComponent<CharacterController>().isGrounded )
			{

				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), follow_speed);
			}
		}
	else
		{ 
		if (target.GetComponent<CharacterController>().isGrounded || water.GetComponent<UnderWater>().is_player_underwater)
		{
			
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), follow_speed);
		}
		}
		if (Keep_last_moving_rotation)
		{
			if (stoped)
			{
				transform.rotation = late_rotation;
			}
			else
			{
				late_rotation = transform.rotation;
			}
		}

	}




}
