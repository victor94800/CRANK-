using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	//varaible
	// global 
	public GameObject global;

	// player information 
	public GameObject player;
	public int life = 100 ;
	public Vector3 pos ;
	public int money = 0 ;

	//bloked items
	public string[] item_name = { "double_jump", "fire_sword", "thunder_sword" };
	public bool[] item_allowed = { false, false, false };
	
	
	// Use this for initialization
	void Start ()
	{
		// initialistion des items
		DontDestroyOnLoad(gameObject);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		try
		{
			player = GameObject.Find("Player");
			global = GameObject.Find("Global");

		}
		catch
		{

		}
		if (player != null)
		{
			life = player.GetComponent<PlayerController>().life;
			pos = player.transform.position;
		}
		if (global != null)
		{
			money = global.GetComponent<Player_money>().Money;
		}

		
	}
}
