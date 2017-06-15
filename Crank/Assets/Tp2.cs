using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp2 : MonoBehaviour {
	public GameObject transistor;
	public Transform destination;
	// Use this for initialization
	

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "PlayerController")
		{
			destination = transistor.GetComponent<Trans>().from;
			other.transform.position = destination.position;
		}
	}
}
