using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playcoffresound : MonoBehaviour {
	private AudioSource audi;
	public AudioClip coffre;
	public GameObject player;
	public Vector3 dirtomain;
	// Use this for initialization
	void Start ()
	{
		audi = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		dirtomain = player.transform.position - transform.position;
		if (dirtomain.magnitude <= 10)
		{
			audi.PlayOneShot(coffre);
			Destroy(this);
		}
	}
}
