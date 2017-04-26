using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {
	public GameObject S_chekpoint;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(new Vector3(5, 0, 0));

		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "player" )
		{
			S_chekpoint.SetActive(true);
			Destroy(gameObject);
			
		}
	}
}
