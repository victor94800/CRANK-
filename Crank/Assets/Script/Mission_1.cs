using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_1 : MonoBehaviour {
	public AudioClip sound_first;
	public AudioClip sound_2;
	
	private AudioSource audi;
	bool is_jump = false;
	bool is_Etuto_Deafed = false;
	GameObject Etuto;
	public GameObject checkpoint;
	public GameObject phonecamera;
	public GameObject FPcamera;
	public GameObject canvas;
	

	int i = 0;
	// Use this for initialization
	void Start ()
	{
		
		if (GameObject.Find("GameController").GetComponent<GameController>().mission == 2)
		{

			checkpoint.SetActive(false);
			
		}
		else
		{
			checkpoint.SetActive(true);
			audi = GetComponent<AudioSource>();
			canvas.GetComponent<OpenClosePhone>().PhoneMission();
			FPcamera.GetComponent<LookAtCam>().target = checkpoint;
		    //GameObject.Find("PhoneBackground")
			

			GetComponent<AudioSource>().PlayOneShot(sound_first);
		}
		audi = GetComponent<AudioSource>();
		
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
			canvas.GetComponent<OpenClosePhone>().PhoneMission();
			FPcamera.GetComponent<LookAtCam>().target = null;
			
			Destroy(this);
		}

	}
}
