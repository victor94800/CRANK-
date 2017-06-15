using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_1_L2 : MonoBehaviour {
	public GameObject AI;
	public AudioClip M1L2_1;
	public GameObject phone;
	public GameObject missionfaild;
	public AudioClip take;
	private AudioSource AS;
	public GameObject FPcamera;
	public GameObject canvas;
	public GameObject finishMission;
	public int pics;
	public bool finishA1;
	public bool finish;
	public AudioClip M1L2_2;
		// Use this for initialization
	void Start ()
	{
		AS = GetComponent<AudioSource>();
		AS.PlayOneShot(M1L2_1);
		AI.SetActive(true);
		FPcamera.GetComponent<LookAtCam>().target =AI;
		canvas.GetComponent<OpenClosePhone>().PhoneMission();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!AS.isPlaying && !finishA1)
		{
			//Player_rend.SetActive(true);

			//GetComponent<mission_1_1>().enabled = true;
			FPcamera.GetComponent<LookAtCam>().target = null;
			canvas.GetComponent<OpenClosePhone>().PhoneMission();
			finishA1 = true;
		}
		if (phone.activeInHierarchy && Input.GetKeyDown("joystick button 5"))
		{
			AS.PlayOneShot(take);
			AI.GetComponent<AIController>().stopmove = false;
			StartCoroutine(restart());
			
			pics += 1;
		}
		if (AI.GetComponent<AIController>().IS_Following_PLayer )
		{
			missionfaild.SetActive(true);
			this.gameObject.SetActive(false);

		}
		if (pics == 4)
		{
			AS.PlayOneShot(M1L2_2);
			
		}
		if (AS.isPlaying && finish)
		{
			finishMission.SetActive(true);
			Destroy(AI);
			Destroy(gameObject);
		}
	}
	public IEnumerator restart()
	{
		yield return new WaitForSeconds(2);
		AI.GetComponent<AIController>().stopmove = true;
	}
}
