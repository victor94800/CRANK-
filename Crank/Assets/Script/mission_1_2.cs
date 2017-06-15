using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_1_2 : MonoBehaviour
{
	public GameObject enemy;
	
	private AudioSource audi;
	public AudioClip enemy_clip;
	public GameObject camera_target;
	public GameObject finish_mission;
	public GameObject FPcamera;
	public GameObject canvas;
	public GameObject player;
	public GameObject Global;
	private bool finish;
	public GameObject Player_rend;
	// Use this for initialization
	void Start ()
	{
		audi = GetComponent<AudioSource>();

		//instenciate ia not mouve 
		//Player_rend.SetActive(false);
		audi.PlayOneShot(enemy_clip);
		enemy.SetActive(true);
		
		FPcamera.GetComponent<LookAtCam>().target = enemy;
		canvas.GetComponent<OpenClosePhone>().PhoneMission();


		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!audi.isPlaying && !finish)
		{
			//Player_rend.SetActive(true);

			//GetComponent<mission_1_1>().enabled = true;
			FPcamera.GetComponent<LookAtCam>().target = null;
			canvas.GetComponent<OpenClosePhone>().PhoneMission();
			finish = true;
		}
		if ( finish && !enemy.activeInHierarchy)
		{

			
			finish_mission.SetActive(true);
			Global.GetComponent<Global>().enemy_active = true;
			GameObject.Find("GameController").GetComponent<GameController>().mission = 3;
			
            Destroy(this);
		}
		
	}
}
