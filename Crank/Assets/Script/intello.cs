using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intello : MonoBehaviour {
	public GameObject sniper;
	public GameObject Mask;
	public bool run;
	public bool walk;
	
	// Use this for initialization
	void Start ()
	{ 
		   
	}
	
	// Update is called once per frame
	void Update ()
	{
	     if(Input.GetAxis("Vertical") != 0)
		{
			walk = true;
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey("joystick button 5"))
			{
				run = true;

			}
			else
			{
				run = false;
			}
		}
		 else

		{
			walk = false;

		}
	}
}
