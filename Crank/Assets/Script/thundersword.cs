using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class thundersword : MonoBehaviour {

	// Use this for initialization
	public GameObject global;
	void Start ()
	{
		
		this.GetComponent<Button>().interactable = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (global.GetComponent<Player_money>().Money >= 1 )
		{
			this.GetComponent<Button>().interactable = true;
		}
		
	}
	public void Onclick()
	{

	}
}
