using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seller : MonoBehaviour {

	// Use this for initialization
	//Transform player;
	Vector3 dirtomain;

	// menu d'achat 
	GameObject sellerscreen;
	public bool test = false;
	void Start ()
	{
		//player = GameObject.Find("Player").transform;
		sellerscreen = GameObject.Find("seller");

		//sellerscreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		dirtomain = GameObject.Find("Player").transform.position - transform.position;
		if (dirtomain.magnitude < 3 && Input.GetKey("joystick button 1"))
		{
			SceneManager.LoadScene(3);
		}
		

	}
}
