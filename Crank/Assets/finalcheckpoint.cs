using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalcheckpoint : MonoBehaviour {
	public mission_1_1 m12;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "PlayerController" )
		{
			m12.enabled = true;
			Destroy(gameObject);
		}
	}
}
