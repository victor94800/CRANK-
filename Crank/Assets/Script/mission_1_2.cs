using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_1_2 : MonoBehaviour {
	public GameObject enemy;
	public GameObject[] startpoint;
	private AudioSource audi;
	public AudioClip enemy_clip;
	public GameObject camera_target;
	public GameObject finish_mission;
	public GameObject phone;
	public GameObject intello;
	public GameObject background;
	public GameObject camera2;
	private GameObject camera1;
	public GameObject player;
	public GameObject Global;
	public GameObject apps;
	public GameObject Player_rend;
	// Use this for initialization
	void Start ()
	{
		audi = GetComponent<AudioSource>();

		//instenciate ia not mouve 
		Player_rend.SetActive(false);
		audi.PlayOneShot(enemy_clip);
		phone.SetActive(true);
		intello.SetActive(true);
		player.GetComponent<PlayerController>().enabled = true;
		camera2.SetActive(true);
		camera1 = GameObject.Find("Camera");
		camera1.SetActive(false);
		camera2.GetComponent<phonecamera>().target_p = camera_target;
		apps.SetActive(false);
		//GameObject.Find("PhoneBackground")
		background.SetActive(false);


		GetComponent<IACreator>().InstentiateIA(1,startpoint[0].transform.rotation , enemy,startpoint);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!audi.isPlaying)
		{
			Player_rend.SetActive(true);
			intello.SetActive(false);
			apps.SetActive(true);
			intello.SetActive(false);
			background.SetActive(true);
			phone.SetActive(false);
			camera1.SetActive(true);
			camera2.GetComponent<phonecamera>().target_p = null;
			camera2.SetActive(false);
			//GetComponent<mission_1_1>().enabled = true;

			player.GetComponent<PlayerController>().enabled = true;
		}
		if (Global.GetComponent<Player_money>().Money >= 2  )
		{
			
			
			finish_mission.SetActive(true);
			Global.GetComponent<Global>().enemy_active = true;
			Destroy(this);
		}
		
	}
}
