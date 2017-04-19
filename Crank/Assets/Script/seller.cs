using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seller : MonoBehaviour {

	// Use this for initialization
	//Transform player;
	Vector3 dirtomain;
	public bool test = false;
	void Start ()
	{
		//player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{

		dirtomain = GameObject.Find("Player").transform.position - transform.position;
		if (dirtomain.magnitude < 3 && Input.GetKey("joystick button 0"))
		{
			Global.dubblejump_allowed = true;
			test = true;
		}
		

	}
}
