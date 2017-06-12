using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour {
	private Animator anim;
	public bool walk;
	public bool Run;
	public bool jump;
	public bool attack;
	public Collider colliderP;
	public float attack_time;
	healthBarre Barredevie;
	public int life;
	public float jumpforce;
	public GameObject player;
	public GameObject jet;
	public bool damage;
	public bool die;
	// Use this for initialization
	void Start ()
	{

		anim = GetComponent<Animator>();
		colliderP.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (player.GetComponent<PlayerController>().fall == false)
		{
			jet.SetActive(false);
		}
		if (player.GetComponent<PlayerController>().onground == true)
		{ 
		if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
		{
			walk = true;
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey("joystick button 5"))
			{
				Run = true;
			}
			else
			{
				Run = false;
			}
		}
		else
		{
			walk = false;
		}
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey("joystick button 5"))
		{
			Run = true;
		}
		else
		{
			Run = false;
		}
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
		{
			jump = true;
			jet.SetActive(true);
			player.GetComponent<PlayerController>().Jump = true;
			
			player.GetComponent<PlayerController>().verticalVelocity = jumpforce;
			
		}
		else
		{
			jump = false;
			//jet.SetActive(false);
			player.GetComponent<PlayerController>().Jump = false;
		}
		if (Input.GetKey("e") || Input.GetKey("joystick button 3"))
		{
			attack = true;
			
			

		}
		else
		{
			attack = false;
		}
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("punch_21"))
		{
			// Avoid any reload.
			colliderP.enabled = true;
		}
		else
		{
			colliderP.enabled = false;
		}
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("GetHit02"))
			{
				player.GetComponent<PlayerController>().enabled = false;
				damage = false;
			}
			else
			{
				player.GetComponent<PlayerController>().enabled = true;
			}
		anim.SetBool("attak", attack);
		anim.SetBool("damage", damage);
		anim.SetBool("die", die);
		anim.SetBool("jump", jump);
		anim.SetBool("walk", walk);
		anim.SetBool("run", Run);

		}
		else
		{
			anim.SetBool("attak", false);
		
			anim.SetBool("walk",false);
			anim.SetBool("run", false);
		}
		/*	if (is_sword_active)
			{
				Sword.GetComponent<BoxCollider>().enabled = true;
			}
			else
			{
				Sword.GetComponent<BoxCollider>().enabled = false;
			}
			*/
	}
	
}
