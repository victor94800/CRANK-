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

	// Use this for initialization
	void Start ()
	{

		GetComponent<AudioSource>().PlayOneShot(m_1_1);
		
		phone.SetActive(true);
		GameObject.Find("Camera2").SetActive(true);
		GameObject.Find("Camera").SetActive(false);
		GameObject.Find("Camera2").GetComponent<phonecamera>().target_p = camera_target;
		GameObject.Find("apps").SetActive(false);
		GameObject.Find("PhoneBackground").SetActive(false);
		phonecamera.GetComponent<Camera>().fieldOfView = 10;

	}

	// Update is called once per frame
	void Update ()
	{
		if (!audi.isPlaying)
		{
			phonecamera.GetComponent<Camera>().fieldOfView = 60;
			GameObject.Find("Intello").SetActive(false);
			phone.SetActive(false);
			GameObject.Find("Camera1").SetActive(true);
			GameObject.Find("Camera2").GetComponent<phonecamera>().target_p = null;
			GameObject.Find("Camera2").SetActive(false);
			
			Destroy(this);
		}
	}
}
