using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mission_1_1 : MonoBehaviour {
	public GameObject player;
	public AudioClip m_1_1;
	
	public GameObject canvas;
	public GameObject phonecamera;
	public GameObject camera_target;
	private AudioSource audi;
	public GameObject FPcamera;
	public GameObject Player_Renderer;
	
	private GameObject GameController;
	private bool finish;

	// Use this for initialization
	void Start ()
	{
		if (GameObject.Find("GameController").GetComponent<GameController>().mission == 2)
		{
			Destroy(this);
		}
		else
		{

			GameController = GameObject.Find("GameController");
			audi = GetComponent<AudioSource>();
			GetComponent<AudioSource>().PlayOneShot(m_1_1);
			//Player_Renderer.SetActive(false);*
			canvas.GetComponent<OpenClosePhone>().PhoneMission();
			
			
			FPcamera.GetComponent<LookAtCam>().target = camera_target;
			phonecamera.GetComponent<Camera>().fieldOfView = 20;
		}

	}

	// Update is called once per frame
	void Update ()
	{
		if (!audi.isPlaying && !finish)
		{
			phonecamera.GetComponent<Camera>().fieldOfView = 60;
			canvas.GetComponent<OpenClosePhone>().PhoneMission();
			FPcamera.GetComponent<LookAtCam>().target = null;
			finish = true;
			
		}
		if (finish && GameController.GetComponent<GameController>().item_allowed[Array.IndexOf(GameController.GetComponent<GameController>().item_name, "fire_sword")])
		{
			GetComponent<mission_1_2>().enabled = true;
			Destroy(this);
		}
	}
}
