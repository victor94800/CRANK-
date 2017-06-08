using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chekpointmission : MonoBehaviour {

	// Use this for initialization
	public GameObject global;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(new Vector3(5, 0, 0));
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "player")
		{
			global.GetComponent<mission_1_1>().enabled = true;
			Destroy(gameObject);
		}
	}
}
