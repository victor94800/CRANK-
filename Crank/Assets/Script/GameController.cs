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
	public int mission;
	public GameObject player;
	public int life = 100 ;
	public Vector3 pos ;
	public int money = 0 ;
	public bool m_1 = true;
	public bool m_2 = false;
	public bool m_3 = false;
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
			player = GameObject.Find("player");
			
			

		}
		catch
		{
			player = null;
		}
		try
		{
			player = GameObject.Find("player");
			global = GameObject.Find("Global");


		}
		catch
		{
			global = null;
			player = null;
		}
		try
		{
			shop = GameObject.Find("GlobShop");


		}
		catch
		{
			shop = null;
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
		if (shop != null)
		{
			money = shop.GetComponent<ChangeButtonNameWhenCilck>().money;
			item_allowed[Array.IndexOf(item_name, "fire_sword")] = shop.GetComponent<ChangeButtonNameWhenCilck>().ISfireswordallowed;
			item_allowed[Array.IndexOf(item_name, "double_jump")] = shop.GetComponent<ChangeButtonNameWhenCilck>().isdoublejumpallowed;
			item_allowed[Array.IndexOf(item_name, "thunder_sword")] = shop.GetComponent<ChangeButtonNameWhenCilck>().isthunderswordallowed;

		}

		
	}
}
