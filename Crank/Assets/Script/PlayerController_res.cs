using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;


public class PlayerController_res : NetworkBehaviour
{

	// attribut de player 
	private CharacterController controller;

	
	// deplacements de player
	private bool Run = false;
	public float Speed;
	private Vector3 moveVector = Vector3.zero;
	
	public float rotatespeed = 100;

	// animation de player 
	public Animator anim;

	// pysique de player 
	public float verticalVelocity;
	public float gravity = 60f;
	public float jumpForce = 15f;
	public float speed = 5;
	public float runspeed = 10;

	// game object associer a player
	public bool walk;


	// autres 
	double time;
	double time2;
	public GameObject Gamecontroller;
	public bool fall;

	private Transform MyTransform;
	public GameObject Third_Camera;
	public GameObject Crank;
	public GameObject player;
	public bool Jump;

	// Use this for initialization
	void Start()
	{
		
		// initialisation dest component de player 
		controller = GetComponent<CharacterController>();
		MyTransform = GetComponent<Transform>();
		if (isLocalPlayer)
		{
			Third_Camera.gameObject.transform.parent = null;
			Third_Camera.GetComponent<Camera>().enabled = true;
			
		}
		
		Crank.SetActive(true);
		Crank.gameObject.transform.parent = null;
		player = Crank;
		
		
	}

	// Update is called once per frame
	void Update()
	{
		
		// update de controller 
		controller = GetComponent<CharacterController>();
		if (verticalVelocity > -5)
		{
			fall = true;
		}
		else
		{
			fall = false;
		}
		if (isLocalPlayer)
		{

			// mouvements de player 
			// mouvements de player 
			if (controller.isGrounded)// le player est il a sol 
			{
			
				verticalVelocity -= gravity * Time.deltaTime;
				Jump = false; // l'aniamtion saut n'as pas besoin d'etre jouée 




				if (Input.GetKey("joystick button 5"))
				{
					Run = true;


				}
				else
				{
					Run = false;


				}
				if (Run) // le joueur est il en train de courrir 
				{
					Speed = runspeed;
				}
				else
				{
					Speed = speed;
				}
			


				if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
				{
					player.GetComponent<follow>().stoped = false;
					walk = true;
					player.GetComponent<follow>().late_rotation = transform.rotation;

				}
				else
				{
					walk = false;
					player.GetComponent<follow>().stoped = true;
				}
				 
				

				moveVector = new Vector3(0, 0, Input.GetAxis("Vertical") * Speed); // le deplacement du joueur 

				moveVector = transform.TransformDirection(moveVector);




			}
			else // le joueur n'est pas au sol
			{
			  
				
				verticalVelocity -= gravity * Time.deltaTime;
				
			}







			transform.RotateAround(Third_Camera.transform.position, Vector3.up, Input.GetAxis("Horizontal") * 100 * Time.deltaTime);//la rotation se fait autour de la camera 




			moveVector = Vector3.zero;

			moveVector.y = verticalVelocity; // on applique la gravitée au joueur 
			moveVector.z = Input.GetAxis("Vertical") * Speed;
			moveVector = transform.TransformDirection(moveVector);
			controller.Move(moveVector * Time.deltaTime); // on effectue les deplacements
			







		}
	}
	

}
