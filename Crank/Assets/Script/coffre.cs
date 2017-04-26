using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffre : MonoBehaviour {
	public GameObject global;
	private AudioSource audi;
	public AudioClip Coffre;
	public GameObject S_chekpoint;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(new Vector3(5, 0, 0));


	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "player")
		{
			audi.PlayOneShot(Coffre);
			S_chekpoint.SetActive(true);
			
			Destroy(gameObject);
			
		}
	}
}
