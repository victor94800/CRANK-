using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour {
	//varaible


	// global 
	public GameObject global;
	public GameObject shop;
	// player information 
	
	public GameObject player;
	public int life = 100 ;
	public Vector3 pos ;
	public int money = 0 ;
	public string player_name;
	
	//bloked items
	public string[] item_name = { "double_jump", "fire_sword", "thunder_sword" };
	public bool[] item_allowed = { false, false, false };

	// sound 
	public float V_music;
	public float V_effect;

	//missions
	public int mission;

	//scene
	public int Level;

	//
	// Use this for initialization
	void Start ()
	{
		// initialistion des items
		DontDestroyOnLoad(gameObject);
		
	}
	
	// Update is called once per frame
/*	void Update ()
	{
		
		
	

		
	}
	*/
}
