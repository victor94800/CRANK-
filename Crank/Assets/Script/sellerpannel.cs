using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellerpannel : MonoBehaviour {

	// Use this for initialization
	Player_money money;

	GameObject button1;
	void Start ()
	{
		money = GetComponent<Player_money>();
		button1 = GameObject.Find("BuyButton1");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
