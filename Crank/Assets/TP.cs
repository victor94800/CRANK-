using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour {
	public Transform destination;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "PlayerController")
			other.transform.position = destination.position;
	}
}
