using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission1_1_2 : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public GameObject global;
	public float heigh;
	private bool completed;
	

	void Start ()
	{

		if (GameObject.Find("GameController").GetComponent<GameController>().mission != 2)
		{
			Destroy(this);
		}
		else
		{

			global = GameObject.Find("Global");
		}
	}
	
	// Update is called once per frame
	void Update ()

	{ 
		if (player.transform.position.y >= heigh)
		{
			completed = true;
		}
		if (completed == true && player.GetComponent<PlayerController>().onground)
		{
			GetComponent<mission_1_2>().enabled = true;
			Destroy(this);
		}
		
	}
}
