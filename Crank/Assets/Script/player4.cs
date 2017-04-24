using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player4 : MonoBehaviour {




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
	public float rotatespeed;
	public float sensibility;

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

		moveVector = Vector3.zero;
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
			print(Input.GetAxis("Horizontal2"));
			if (Input.GetAxis("Horizontal2") > 0.5 || Input.GetAxis("Horizontal2") < -0.5 )
			{
				transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal2") * Time.deltaTime * sensibility, 0f));
			}
			/*if  (Input.GetAxis("Vertical2") > 0.5 || Input.GetAxis("Vertical2") < -0.5)
			{
				
				transform.Rotate(new Vector3(Input.GetAxis("Horizontal2") * Time.deltaTime * sensibility, 0f, 0f));
			}*/
			

				//var target = GameObject.Find("center");
				//Vector3 newRotation = new Vector3(0, Input.GetAxis("Horizontal2") * Time.deltaTime * sensibility, 0);
				//this.transform.eulerAngles = new Vector3(0f, Input.GetAxis("Horizontal2") * Time.deltaTime * sensibility, 0f);
				//transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal2") * Time.deltaTime * 100, 0));
				//transform.rotation =  Quaternion.Euler(0f,camera.transform.rotation.y,0f);
				//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(), 10f);
				moveVector = new  Vector3(0, 0, Input.GetAxis("Vertical")*Speed); // le deplacement du joueur 
				//transform.rotation = new Quaternion(0f,transform.rotation.y,0f,0f);

				moveVector = transform.TransformDirection(moveVector);

				//moveVector *= Speed;
			// on applique la vitesse de deplacements 

			if (Input.GetKeyDown("joystick button 0")) // si le joueur appuis sur la touche x le personnage vas sauter;
			{

				verticalVelocity  = jumpForce;
				//moveVector.y = jumpForce;
			}

		}
		else // le joueur n'est pas au sol
		{
			verticalVelocity  = -gravity * Time.deltaTime;
			//moveVector = new Vector3(0, 0, Input.GetAxis("Vertical") * Speed); // le deplacement du joueur 


			//moveVector = transform.TransformDirection(moveVector);
		}
		//moveVector = Vector3.zero;
		/*if (Input.GetAxis("Horizontal") != 1/*Input.GetAxis("Horizontal") < 0.7 && Input.GetAxis("Horizontal") > -0.7)
		{
			moveVector.x = Input.GetAxis("Horizontal") * 5f;
		}
		else*/
		//{
			transform.RotateAround(camera.transform.position, Vector3.up, Input.GetAxis("Horizontal") * rotatespeed* Time.deltaTime);
		//}
		print(controller.isGrounded);
		moveVector.y = verticalVelocity; // on applique la gravitée au joueur 
		//moveVector.z = Input.GetAxis("Vertical") * 5f;
		controller.Move(moveVector * Time.deltaTime); // on effectue les deplacements 






	}
}
