using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnderWater : MonoBehaviour {

	// objet a detecter sous l'eau;
	public bool is_player_underwater; // le player est sous l'eau
	public bool is_camera_underwater; // la camera est sous l'eau

	private Color Normalcolor;
	private Color UnderwaterColor;
	
	//player
	public GameObject player;
	private Animator Player_anim;

	
	// Use this for initialization
	void Start()
	{
		Normalcolor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		UnderwaterColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
		try
		{
			
			
			Player_anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
			Player_anim.SetBool("Is_underwater", is_player_underwater);
		}
		catch
		{
			Debug.Log("there is no player on the scene");
		}

		player.GetComponent<playerunderwtaer>().enabled = false;

	}

	// Update is called once per frame
	/*void Update()
	{


		
		

	}*/

	void SetNormal()
	{
		RenderSettings.fogColor = Normalcolor;
		RenderSettings.fogDensity = 0f;
	}
	void SetUnderwater()
	{
		RenderSettings.fogColor = UnderwaterColor;
		RenderSettings.fogDensity = 0.05f;
	}
	public void OnTriggerEnter(Collider other)
	{
		print(other.transform.name);
		if (other.transform.name == "Camera")
		{
			is_camera_underwater = true;
			SetUnderwater();
		}
		if (other.transform.name == "PlayerHead")
		{
			is_player_underwater = true;
			Player_anim.SetBool("Is_underwater", true);
			
			player.GetComponent<playerunderwtaer>().enabled = true;
			player.GetComponent<PlayerController>().enabled = false;

		}
	}
	public void OnTriggerStay(Collider other)
	{
		print(other.transform.name);
		if (other.transform.name == "Camera")
		{
			is_camera_underwater = true;
			
		}
		if (other.transform.name == "PlayerHead")
		{
			is_player_underwater = true;
			Player_anim.SetBool("Is_underwater", true);

		}
	}
	public void OnTriggerExit(Collider other)
	{
		print(other.transform.name);
		if (other.transform.name == "Camera")
		{
			is_camera_underwater = false;
			SetNormal();
		}
		if (other.transform.name == "PlayerHead")
		{
			print("enter");
			is_player_underwater = false;
			Player_anim.SetBool("Is_underwater", false);
			
			player.GetComponent<playerunderwtaer>().enabled = false; // la desactivation de playerunderwater entraine automatiquement la reactivation de player controller
			
		}
		
	}
	
	

}
