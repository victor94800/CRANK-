using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_1_1 : MonoBehaviour {
	public GameObject player;
	public AudioClip m_1_1;
	public float height;
	public GameObject phone;
	public GameObject phonecamera;
	public GameObject camera_target;
	private AudioSource audi;
	public GameObject intello;
	public GameObject background;
	public GameObject playerrenderer;
	private GameObject camera1;
	private GameObject GameController;
	public GameObject apps;

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
			playerrenderer.SetActive(false);
			phone.SetActive(true);
			intello.SetActive(true);
			player.GetComponent<player4>().enabled = false;
			phonecamera.SetActive(true);
			camera1 = GameObject.Find("Camera");
			camera1.SetActive(false);
			phonecamera.GetComponent<phonecamera>().target_p = camera_target;
			apps.SetActive(false);
			//GameObject.Find("PhoneBackground")
			background.SetActive(false);
			phonecamera.GetComponent<Camera>().fieldOfView = 20;
		}

	}

	// Update is called once per frame
	void Update ()
	{
		if (!audi.isPlaying)
		{
			phonecamera.GetComponent<Camera>().fieldOfView = 60;
			intello.SetActive(false);
			GameController.GetComponent<GameController>().mission = 2;
			apps.SetActive(true);
			intello.SetActive(false);
			background.SetActive(true);
			phone.SetActive(false);
			camera1.SetActive(true);
			phonecamera.GetComponent<phonecamera>().target_p = null;
			phonecamera.SetActive(false);
			playerrenderer.SetActive(true);
			//GetComponent<mission_1_1>().enabled = true;
			
			player.GetComponent<player4>().enabled = true;
			Destroy(this);
		}
	}
}
