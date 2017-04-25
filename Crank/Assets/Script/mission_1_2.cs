using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_1_2 : MonoBehaviour {
	public GameObject enemy;
	public AudioClip finish_m_1_2;
	public GameObject finish_mission;
	// Use this for initialization
	void Start ()
	{
		//instenciate ia not mouve 
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enemy.active == false )
		{
			GetComponent<AudioSource>().PlayOneShot(finish_m_1_2);
			finish_mission.SetActive(true);
			Destroy(this);
		}
		
	}
}
