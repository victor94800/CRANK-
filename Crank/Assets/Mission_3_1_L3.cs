using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_3_1_L3 : MonoBehaviour {
	public AudioClip M1L3_3;
	public AudioClip M1L3_4;
	public GameObject finalboss;
	public AudioSource AS;
	public GameObject M3_Fm;
	public bool F1;
	public bool F2;
	public bool F3;
	public bool finsish;
	// Use this for initialization
	void Start ()
	{
		AS = GetComponent<AudioSource>();
		AS.PlayOneShot(M1L3_3);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!AS.isPlaying && !F1)
		{
			F1 = true;
		}
		else if (F1 && !F2)
		{
			if (!finalboss.activeInHierarchy)
			{
				F2 = true;
			}
		}
		else if (F2 && !F3)
		{
			AS.PlayOneShot(M1L3_4);
			F3 = true;
		}
		else if (!AS.isPlaying && F3)
		{
			M3_Fm.SetActive(true);
			Destroy(this);
		}
       
		

		

	}
}
