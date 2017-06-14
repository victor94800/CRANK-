using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
	public Transform destination;
	public GameObject transistor;
	// Use this for initialization
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "PlayerController")
		{
			transistor.GetComponent<Trans>().from = transform;
			other.transform.position = destination.position;
		}
	}
}
