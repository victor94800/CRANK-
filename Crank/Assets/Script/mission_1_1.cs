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
	public GameObject Player_Renderer;
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
			Player_Renderer.SetActive(false);
			phone.SetActive(true);
			intello.SetActive(true);
			player.GetComponent<PlayerController>().enabled = false;
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
			Player_Renderer.SetActive(true);
			//GetComponent<mission_1_1>().enabled = true;

			player.GetComponent<PlayerController>().enabled = true;
			Destroy(this);
		}
	}
}
