using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player3 : MonoBehaviour
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




	// pysique de player 
	private float verticalVelocity;
	public float gravity = 10.0f;
	public float jumpForce = 5000.0f;
	public float speed = 10;
	public float runspeed = 20;

	// game object associer a player
	GameObject sword;
	GameObject thundersword;
	GameObject fireSword;
	public GameObject camera;

	// autres 
	double time;
	double time2;
	public GameObject Gamecontroller;

	Vector3 dirtomain;

	// capacites de player a debloquer
	private bool TunderSword_allowed = false;
	private bool fireSword_allowed = false;
	private bool ddjump_allowed = false;





	// Use this for initialization
	void Start()
	{
		// initialisation dest component de player 
		controller = GetComponent<CharacterController>();

		//animateur 


		// inGitialisation des objets associés a player 
		sword = GameObject.Find("PlayerS");
		fireSword = GameObject.Find("firesword");
		thundersword = GameObject.Find("thundersword");
		try
		{
			Gamecontroller = GameObject.Find("GameController");
		}
		catch
		{
			Gamecontroller = null;
		}

		if (Gamecontroller != null && Gamecontroller.GetComponent<GameController>().pos != Vector3.zero)
		{

			this.transform.position = Gamecontroller.GetComponent<GameController>().pos + new Vector3(0, 6, 0);

		}

		fireSword.SetActive(false);


		thundersword.SetActive(false);


	}

	// Update is called once per frame
	void Update()
	{
		//dirtomain = camera.transform.position - transform.position;
		// update de controller 
		controller = GetComponent<CharacterController>();

		//actions 


		// mouvements de player 
		if (controller.isGrounded)// le player est il a sol 
		{
			
			Jump = false; // l'aniamtion saut n'as pas besoin d'etre jouée 

			dubble_jump = true; // le double jump est de nouveau possible 

			if (Run) // le joueur est il en train de courrir 
			{
				Speed = runspeed;
			}
			else
			{
				Speed = speed;
			}

			//transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * Time.deltaTime * 100, 0)); // la rotaion de joueur

			moveVector = new Vector3(0, 0, Input.GetAxis("Vertical")); // le deplacement du joueur 
			if (Input.GetAxis("Vertical") == 1)
			{                                                              //raport camera
				
					//camera.transform.rotation = Quaternion.Euler(camera.transform.rotation.x, transform.rotation.y, camera.transform.rotation.z);
				
			}
			else
			{
				//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 10f);
				//camera.transform.rotation = transform.rotation;
			}
			moveVector = transform.TransformDirection(moveVector);

			moveVector *= Speed; // on applique la vitesse de deplacements 

			if (Input.GetKeyDown("joystick button 0")) // si le joueur appuis sur la touche x le personnage vas sauter;
			{

				//verticalVelocity  = jumpForce;
				moveVector.y = jumpForce;
			}

		}
		else
		{
			//verticalVelocity
			moveVector.y = -gravity * Time.deltaTime;
		}
		/*moveVector = Vector3.zero;
		//moveVector.x = Input.GetAxis("Horizontal") * 5f;
		moveVector.y = verticalVelocity; // on applique la gravitée au joueur 
		moveVector.z = Input.GetAxis("Vertical") * 5f;*/
		controller.Move(moveVector * Time.deltaTime); // on effectue les deplacements 





	}
}
