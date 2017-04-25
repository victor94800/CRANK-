using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission1_1_2 : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public GameObject global;
	public int heigh;

	void Start ()
	{
		global = GameObject.Find("Global");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (player.transform.position.y >= heigh)
		{
			GetComponent<mission_1_2>().enabled = true;
			GameObject.Find("GameController").GetComponent<GameController>().mission = 2;
			GetComponent<mission_1_2>().enabled = true;
			Destroy(this);
		}
		
	}
}
