using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warior : MonoBehaviour {
	private Animator anim;
	public bool walk;
	public bool Run;
	public bool jump;
	public bool attack;
	public GameObject Sword;
	public float attack_time;
	private bool is_sword_active;
	public Collider colliderS;
	// Use this for initialization
	void Start ()
	{
		
		anim = GetComponent<Animator>();
		Sword = GameObject.Find("warriorS");
		//colliderS = Sword.GetComponent<Collider>();
		colliderS.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
		{
			walk = true;
			if (Input.GetKey(KeyCode.LeftShift) ||Input.GetKey("joystick button 5"))
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
		if (Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 0"))
		{
			jump = true;
		}
		else
		{
			jump = false;
		}
		if (Input.GetKey("e") ||Input.GetKey("joystick button 3") )
		{
			attack = true;
			StartCoroutine(Wait());
			//Sword.GetComponent<BoxCollider>().enabled = true;
			
		}
		else
		{
			attack = false;
		}

		anim.SetBool("attak", attack);
		anim.SetBool("jump", jump);
		anim.SetBool("walk", walk);
		anim.SetBool("run", Run);
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
	public IEnumerator Wait()
	{
		
		yield return new WaitForSeconds(attack_time);
	
		//Sword.GetComponent<BoxCollider>().enabled = true;
		is_sword_active = true;
		colliderS.enabled = true;
		StartCoroutine(Lait());
	}
	public IEnumerator Lait()
	{
		
		yield return new WaitForSeconds(attack_time);

		//Sword.GetComponent<BoxCollider>().enabled = false;
		colliderS.enabled = false;
	}
}
