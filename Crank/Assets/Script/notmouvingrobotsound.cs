using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notmouvingrobotsound : MonoBehaviour {


	public AudioClip attak;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (this.GetComponent<notMovingIA>().Attack)
		{
			if (!GetComponent<AudioSource>().isPlaying)
			{
				GetComponent<AudioSource>().Stop();
				GetComponent<AudioSource>().PlayOneShot(attak);
			}
		}
		else
		{
			if (!GetComponent<AudioSource>().isPlaying)
			{
				GetComponent<AudioSource>().Stop();
			}
			
		}
	}
}
