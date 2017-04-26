using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_1 : MonoBehaviour {
	public AudioClip sound_first;
	public AudioClip sound_2;
	public GameObject phone;
	public GameObject phonecamera;
	public GameObject camera_target;
	private AudioSource audi;
	bool is_jump = false;
	bool is_Etuto_Deafed = false;
	GameObject Etuto;
	public GameObject[] checkpoints;
	public GameObject start;
	int i = 0;
	// Use this for initialization
	void Start ()
	{
		
		foreach(GameObject i in checkpoints)
		{
			i.SetActive(false);
		}
		start.SetActive(  false);
		phone.SetActive(true);
		GameObject.Find("Camera2").SetActive(true);
		GameObject.Find("Camera").SetActive(false);
		GameObject.Find("Camera2").GetComponent<phonecamera>().target_p = camera_target;
		GameObject.Find("apps").SetActive(false);
		GameObject.Find("PhoneBackground").SetActive(false);
		
		GetComponent<AudioSource>().PlayOneShot(sound_first);

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!audi.isPlaying && i == 0)
		{
			GetComponent<AudioSource>().PlayOneShot(sound_2);
			phonecamera.GetComponent<Camera>().fieldOfView = 10;
			i += 1;
		}
		if (!audi.isPlaying && i == 1)
		{
			phonecamera.GetComponent<Camera>().fieldOfView = 60;
			GameObject.Find("Intello").SetActive(false);
			phone.SetActive(false);
			GameObject.Find("Camera1").SetActive(true);
			GameObject.Find("Camera2").GetComponent<phonecamera>().target_p = null;
			GameObject.Find("Camera2").SetActive(false);
			GetComponent<mission_1_1>().enabled = true;
			Destroy(this);
		}

	}
}
