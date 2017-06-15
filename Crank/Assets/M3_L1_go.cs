using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3_L1_go : MonoBehaviour {
	public AudioSource AS;
	// Use this for initialization
	void Start () {
		AS.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	private void OnTriggerEnter(Collider other)
	{
		AS.enabled = true;
	}
}
