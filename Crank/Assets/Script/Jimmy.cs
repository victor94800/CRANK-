using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jimmy : MonoBehaviour {
	public float lengh;
	public float jumpforce;
	private Animator anim;
	public bool walk;
	public bool Run;
	public bool jump;
	public bool attack;
	public GameObject sniper;
	public bool snip;
	public float attack_time;
	healthBarre Barredevie;
	public GameObject Scam;
	public Transform origin;
	public bool die;
	public bool damage;
	public int life;
	public GameObject player;
	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		
	}

	// Update is called once per frame
	void Update()
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
		if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 5"))
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
			StartCoroutine(Jump());
		}
		else
		{
			jump = false;
		}
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("damage_25"))
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

		if (Input.GetKeyDown("joystick button 9"))
		{
			sniper.SetActive(!sniper.activeInHierarchy);
			Scam.SetActive(!Scam.activeInHierarchy);
			snip = !snip;
		}
		if (snip)
		{
			if (Input.GetKeyDown("joystick button 3"))
			{

				RaycastHit hit;
				/*if (Physics.Raycast(origin.position, origin.transform.forward, out hit, lengh))
					{
					print(hit.transform.name);
					Debug.DrawRay(origin.position, hit.point);
				}
					*/
				Ray ray = Scam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
				
				
				if (Physics.Raycast(ray, out hit , lengh))
				{
					print("I'm looking at " + hit.transform.tag);
					Debug.DrawLine(transform.position, hit.transform.position, Color.red,20);
					if(hit.transform.tag == "enemy")
					{
						hit.transform.SendMessage("getHit", 10);
					}
				}
					
				else
					print("I'm looking at nothing!");
					
			}
		
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
		player.GetComponent<PlayerController>().verticalVelocity = jumpforce;



	}


}
