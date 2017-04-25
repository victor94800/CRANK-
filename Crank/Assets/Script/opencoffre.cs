using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencoffre : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public GameObject global;
	public Vector3 dirtomain;
	
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		dirtomain = player.transform.position - transform.position;
		if (dirtomain.magnitude <= 2)
		{
			if (Input.GetKey("joystick button 1"))
			{
				global.GetComponent<Player_money>().AddMoney(300);
				Destroy(this);
			}
		}

	}
}
