using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
	// attribut de player 
	private CharacterController controller;

	// action  de player 
	private bool Attack = false;
	private bool Attack1 = false;

	// deplacemtn de player
	private bool Run = false;
	public float Speed;
	private float inputH;
	private float inputV;
	private Vector3 moveVector = Vector3.zero;
	private bool Jump = false;
	public bool dubble_jump = true;
	private bool ddjump = false;


	// animation de player 
	public Animator anim;

	// pysique de player 
	private float verticalVelocity;
	public float gravity = 60f;
	public float jumpForce = 15f;
	public float speed = 5;
	public float runspeed = 10;

	// game object associer a player
	GameObject sword;
	GameObject thundersword;
	GameObject fireSword;


	// autres 
	double time;
	double time2;
	public GameObject Gamecontroller;

	// capacites de player a debloquer
	private bool TunderSword_allowed = false;
	private bool fireSword_allowed = false;
	private bool ddjump_allowed = false;






	// Use this for initialization
	void Start()
	{
		// initialisation dest component de player 
		controller = GetComponent<CharacterController>();

		
	}

	// Update is called once per frame
	void Update()
	{
		// update de controller 
		controller = GetComponent<CharacterController>();

		if (isLocalPlayer)
		{ 


			
			
			
			
			// mouvements de player 
			if (controller.isGrounded)// le player est il a sol 
			{
				Jump = false; // l'aniamtion saut n'as pas besoin d'etre jouée 
				anim.SetBool("is grounded", true); // le booleen is grounded de l'animator et mis a true 
				dubble_jump = true; // le double jump est de nouveau possible 


				transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * Time.deltaTime * 100, 0)); // la rotaion de joueur

				moveVector = new Vector3(0, 0, Input.GetAxis("Vertical")); // le deplacement du joueur 

				moveVector = transform.TransformDirection(moveVector);

				moveVector *= Speed; // on applique la vitesse de deplacements 

				

					if (Input.GetKeyDown("joystick button 0")) // il fait un double saut  
					{
						moveVector.y = jumpForce;
						dubble_jump = false;
						Jump = true;
					}
				



			}
			moveVector.y -= gravity * Time.deltaTime; // on applique la gravitée au joueur 
			controller.Move(moveVector * Time.deltaTime); // on effectue les deplacements 



		}
	}
}