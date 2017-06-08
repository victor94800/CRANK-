using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SreenShot : MonoBehaviour {

	// Use this for initialization
	public int d = 0;
	
	// Update is called once per fram
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			Take();
		}
	}
	void Take()
	{
		Application.CaptureScreenshot("capture" + d + ".png");
		Debug.Log("test aifkjanvoinav,aoiev,oianevp,aoivnavoicnapio,vcoianzvclaoi ainvouanvhuonvaounvouavouanvoubaoioiuanlfic,naovnoiavS");
		d++;
	}

}
