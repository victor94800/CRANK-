﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_1 : MonoBehaviour {
	bool is_jump = false;
	bool is_Etuto_Deafed = false;
	GameObject Etuto;
	// Use this for initialization
	void Start ()
	{
		Etuto = GameObject.Find("Etuto");
		Etuto.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		is_jump = Global.dubblejump_allowed;
		if (is_jump)
		{
			Etuto.SetActive(true);
		}
		is_Etuto_Deafed = Etuto.active;
		if (is_Etuto_Deafed )
		{
			print("won");
		}
	}
}
