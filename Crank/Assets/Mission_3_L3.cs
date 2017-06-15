using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_3_L3 : MonoBehaviour {
	public GameObject player;
	private AudioSource AS;
	public AudioClip M1L3_1;
	public AudioClip M1L3_2;
	public GameObject guard1;
	public GameObject guard2;
	public bool F1;
	public bool F2;
	public bool F3;
	public bool finish;
	public GameObject[] Guard;
	public GameObject[] Guard2;
	public bool Fguard;
	public bool Fguard2;
	// Use this for initialization
	void Start ()
	{
		guard1.SetActive(true);
		AS = GetComponent<AudioSource>();
		AS.PlayOneShot(M1L3_1);
		player.GetComponent<PlayerController>().playertype = 1;
		player.GetComponent<PlayerController>().selectplayer();
	}
	
	// Update is called once per frame
	void Update ()
	{
	 if (!AS.isPlaying && !F1)
		{

			F1 = true;
		}

		if (!Fguard)
		{
			Fguard = true;
			foreach (GameObject i in Guard)
			{
				if (i.activeInHierarchy == true)
				{
					Fguard = false;
				}
			}
		}
		else if (player.GetComponent<PlayerController>().playertype == 1)
		{
			player.GetComponent<PlayerController>().playertype = 2;
			player.GetComponent<PlayerController>().selectplayer();
			guard2.SetActive(true);
		}
		if (!Fguard2)
		{
			Fguard2 = true;
			foreach (GameObject i in Guard2)
			{
				if (i.activeInHierarchy == true)
				{
					Fguard2 = false;
				}
			}
		}
		else if(player.GetComponent<PlayerController>().playertype == 2 && !finish)
		{
			player.GetComponent<PlayerController>().playertype = 0;
			player.GetComponent<PlayerController>().selectplayer();
			AS.PlayOneShot(M1L3_2);
			finish = true;
		}
		if (!AS.isPlaying && finish)
		{
			GetComponent<Mission_3_1_L3>().enabled = true;
			Destroy(this);
		}
		



	}
}
