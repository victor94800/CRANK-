using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_1 : MonoBehaviour {
	public AudioClip sound_first;
	public GameObject phone;
	bool is_jump = false;
	bool is_Etuto_Deafed = false;
	GameObject Etuto;
	public GameObject[] checkpoints;
	public GameObject start;
	// Use this for initialization
	void Start ()
	{
		Etuto = GameObject.Find("Etuto");
		//Etuto.SetActive(false);
		foreach(GameObject i in checkpoints)
		{
			i.SetActive(false);
		}
		start.SetActive(  false);
		phone.SetActive(true);
		GetComponent<AudioSource>().PlayOneShot(sound_first);

	}
	
	// Update is called once per frame
	void Update ()
	{
		


	}
}
