using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission3_1 : MonoBehaviour {
	public AudioClip StartM3;

	public AudioClip FinishM3;
	public GameObject TP;
	private AudioSource AS;
	public GameObject FinishLevel_1;
	public int next_level;
	public GameObject mino;
	private bool finish;
	public GameObject MissionController;
	// Use this for initialization
	void Start ()
	{
		AS = GetComponent<AudioSource>();
		TP.SetActive(true);
		AS.PlayOneShot(StartM3);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (mino == null)
		{
			FinishLevel_1.SetActive(true);
			AS.PlayOneShot(FinishM3);
			finish = true;
		}
		if (finish && !AS.isPlaying)
		{
			Destroy(gameObject);
		}
	}

}
