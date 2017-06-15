using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seller : MonoBehaviour {

	// Use this for initialization
	//Transform player;
	Vector3 dirtomain;
	
	// menu d'achat 
	public GameObject sellerscreen;
	
	
	
	// Update is called once per frame
	void Update ()
	{
		
		dirtomain = GameObject.FindWithTag("Player").transform.position - transform.position;
		if (dirtomain.magnitude < 3 && Input.GetKey("joystick button 1"))
		{
			sellerscreen.SetActive(true);
		
		}
		if (sellerscreen.activeInHierarchy)
		{
			
			Time.timeScale = 0;
		}
		else
		{
			
			Time.timeScale = 1;
		}

	}
}
