using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Warrior_res : NetworkBehaviour {

	private Animator anim;
	public bool walk;
	public bool Run;
	public bool jump;
	public bool attack;
	public GameObject Sword;
	public float attack_time;
	private bool is_sword_active;
	public Collider colliderS;
	healthBarre Barredevie;
	public int life;
	public float jumpforce;
	public GameObject player;
	public bool fall;
	public bool can_jump;
	public bool damage;
	public bool die = false;
	public bool isunderwtaer;
	// Use this for initialization
	void Start()
	{
		
		anim = GetComponent<Animator>();
		Sword = GameObject.Find("warriorS");
		//colliderS = Sword.GetComponent<Collider>();
		colliderS.enabled = false;
		fall = player.GetComponent<PlayerController_res>().fall;

	}

	// Update is called once per frame
	void Update()
	{
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Walk") || anim.GetCurrentAnimatorStateInfo(0).IsName("Sprint"))
		{
			// Avoid any reload.
			can_jump = true;

		}
		else
		{
			can_jump = false;
		}
		fall = player.GetComponent<PlayerController_res>().fall;
		if (!fall)
		{
			jump = false;
		}




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
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && !fall && can_jump)
		{
			jump = true;
			player.GetComponent<PlayerController_res>().Jump = true;
			StartCoroutine(Jump());
		}
		else if ((Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 0")) && anim.GetBool("Is_underwater"))
		{
			jump = true;

		}
		else
		{
			jump = false;
		}
		if (Input.GetKeyDown("e") || Input.GetKey("joystick button 3"))
		{
			attack = true;

			//Sword.GetComponent<BoxCollider>().enabled = true;

		}
		else
		{
			attack = false;
		}

		if (anim.GetCurrentAnimatorStateInfo(0).IsName("damage_25"))
		{
			player.GetComponent<PlayerController>().enabled = false;
			damage = false;
		}
		else
		{
			player.GetComponent<PlayerController_res>().enabled = true;
		}

		anim.SetBool("die", die);
		anim.SetBool("fall", player.GetComponent<PlayerController_res>().fall);
		anim.SetBool("damage", damage);
		anim.SetBool("attak", attack);
		anim.SetBool("jump", jump);
		anim.SetBool("walk", walk);
		anim.SetBool("run", Run);

		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sword Attack"))
		{
			// Avoid any reload.
			colliderS.enabled = true;
		}
		else
		{
			colliderS.enabled = false;
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

	public IEnumerator Jump()
	{

		yield return new WaitForSeconds(0.15f);
		player.GetComponent<PlayerController_res>().verticalVelocity = jumpforce;



	}

}
