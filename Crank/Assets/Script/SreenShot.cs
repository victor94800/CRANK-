using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SreenShot : MonoBehaviour {

	// Use this for initialization
	void Take ()
	{
		Application.CaptureScreenshot("capture.png");
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("joystick button 5"))
		{
			Take();
		}
	}
}
