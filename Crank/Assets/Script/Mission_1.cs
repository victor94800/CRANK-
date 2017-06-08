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
	public GameObject intello;
	public GameObject background;
	public GameObject camera2;
	private GameObject camera1;
	public GameObject player;
	public GameObject apps;
	int i = 0;
	// Use this for initialization
	void Start ()
	{
		
		if (GameObject.Find("GameController").GetComponent<GameController>().mission == 2)
		{
			foreach (GameObject i in checkpoints)
			{
				i.SetActive(false);
			}
			Destroy(this);
		}
		else
		{

			audi = GetComponent<AudioSource>();

			foreach (GameObject i in checkpoints)
			{
				i.SetActive(false);
			}
			start.SetActive(true);
			phone.SetActive(true);
			intello.SetActive(true);
			player.GetComponent<PlayerController>().enabled = false;
			camera2.SetActive(true);
			camera1 = GameObject.Find("Camera");
			camera1.SetActive(false);
			camera2.GetComponent<phonecamera>().target_p = camera_target;

			apps.SetActive(false);
			//GameObject.Find("PhoneBackground")
			background.SetActive(false);

			GetComponent<AudioSource>().PlayOneShot(sound_first);
		}
		audi = GetComponent<AudioSource>();
		print(audi);
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
			intello.SetActive(false);
			
			apps.SetActive(true);
			phone.SetActive(false);
			camera1.SetActive(true);
			camera2.GetComponent<phonecamera>().target_p = null;
			camera2.SetActive(false);
			//GetComponent<mission_1_1>().enabled = true;
			intello.SetActive(false);
			background.SetActive(true);
			phone.SetActive(false);
			player.GetComponent<PlayerController>().enabled = true;
			Destroy(this);
		}

	}
}
