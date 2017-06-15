using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3_FM : MonoBehaviour {
	public GameObject player;
	public AudioClip finish3;
	public AudioSource AS;
	public bool F1;
	public GameObject spawn;
	// Use this for initialization
	private void Start()
	{
		
	}
	// Update is called once per frame
	void Update ()
	{
	  if (Input.GetKey("joystyck button 3"))
		{
			AS.PlayOneShot(finish3);
			F1 = true;
		}
	  if(!AS.isPlaying && F1)
		{
			player.transform.position = spawn.transform.position;
		}
	}
}
