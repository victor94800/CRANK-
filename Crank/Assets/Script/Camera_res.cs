using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class Camera_res : NetworkBehaviour
{
	public static int cameras;
	// Use this for initialization
	void Start ()
	{
		if(!isLocalPlayer && cameras >= 1 )
		{
			Destroy(gameObject);
		}
		else
		{
			cameras += 1;
		}
		
	}
	
	
}
