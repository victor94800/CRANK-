using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buying : MonoBehaviour {

	// Use this for initialization
	public int cost;

	public GameObject global;

	void Start ()
	{
		global.GetComponent<Player_money>().lossMOney(cost);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
