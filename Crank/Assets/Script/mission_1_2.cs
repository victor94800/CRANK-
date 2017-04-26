using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_1_2 : MonoBehaviour {
	public GameObject enemy;
	public GameObject[] startpoint;
	
	
	public GameObject finish_mission;
	
	// Use this for initialization
	void Start ()
	{
		//instenciate ia not mouve 
		GetComponent<Global>().instanciateIA(1, 50, 10, enemy,startpoint);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enemy.active == false )
		{
			
			finish_mission.SetActive(true);
			Destroy(this);
		}
		
	}
}
