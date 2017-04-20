using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnderWater : MonoBehaviour {
	private Transform tamera;
	GameObject h;
	public bool isunderwater;
	private Color Normalcolor;
	private Color UnderwaterColor;

	//private GameObject under;
	// Use this for initialization
	void Start()
	{
		Normalcolor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		UnderwaterColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
		
	}

	// Update is called once per frame
	void Update()
	{
		
			
		if (isunderwater) SetUnderwater();
		if (!isunderwater) SetNormal();

		

	}
	void SetNormal()
	{
		RenderSettings.fogColor = Normalcolor;
		RenderSettings.fogDensity = 0f;
	}
	void SetUnderwater()
	{
		RenderSettings.fogColor = UnderwaterColor;
		RenderSettings.fogDensity = 0.05f;
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "Camera")
		{
			isunderwater = true;
		}
	}
	public void OnTriggerStay(Collider other)
	{
		print("test");
		if (other.transform.name == "Camera")
		{
			
			isunderwater = true;
		}
	}
	public void OnTriggerExit(Collider other)
	{
		if (other.transform.name == "Camera")
		{
			
			isunderwater = false;
		}
	}
	
	

}
