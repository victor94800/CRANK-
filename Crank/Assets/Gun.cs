using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	// Use this for initialization
	private Vector3 dirtomain;
	private Transform Player;
	void Start () {

		Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		dirtomain = Player.position - transform.position;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 100);
	}
	
}
