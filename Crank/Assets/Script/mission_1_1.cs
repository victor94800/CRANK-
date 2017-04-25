using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_1_1 : MonoBehaviour {
	public GameObject player;
	public AudioClip m_1_1;
	public float height;

	// Use this for initialization
	void Start ()
	{
		GetComponent<AudioSource>().PlayOneShot(m_1_1);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (player.transform.position.y >= height)
		{
			// GetComponent<mission_1_2>().enabled = true;
			Destroy(this);

		}
	}
}
