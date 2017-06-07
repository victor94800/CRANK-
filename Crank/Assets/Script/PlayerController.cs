using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
	
   // attribut de player 
	private CharacterController controller;
	
	public int life;
	public int apnee;


	// action  de player 
	private bool Attack = false;
	private bool Attack1 = false;

	// deplacements de player
	private bool Run = false;
	private float Speed;
	private bool walk = false;
	private Vector3 moveVector = Vector3.zero;
	private bool Jump = false;

	private bool ddjump = false;


	

	// pysique de player 
	private float verticalVelocity;
	public float gravity = 80f;
	public float jumpForce = 13f;
	public float speed = 5f;
	public float runspeed = 13f;
	public float rotatespeed = 100f;
	public float sensibility = 100f;

	// game object associer a player
	GameObject sword;
	GameObject thundersword;
	GameObject fireSword;
	public GameObject Third_Camera;
	public GameObject global;
	healthBarre Barredevie;
	//gamecontroller
	public GameObject Gamecontroller;
	public GameController Game_controller_script;
	// autres 
	double time;
	
	

	Vector3 dirtomain;
	public bool onground;
	// capacites de player a debloquer
	/*private bool TunderSword_allowed = false;
	private bool fireSword_allowed = false;*/
	public bool ddjump_allowed = false;

	public GameObject player;



	// Use this for initialization
	void Start()
	{
		// initialisation dest component de player 
		player = GameObject.FindWithTag("Player");
		controller = GetComponent<CharacterController>();


		//animateur 


		// inGitialisation des objets associés a player 
		
		/*fireSword = GameObject.Find("firesword");
		thundersword = GameObject.Find("thundersword");*/
		try
		{
			Gamecontroller = GameObject.Find("GameController");
			Game_controller_script = Gamecontroller.GetComponent<GameController>();
		}
		catch
		{
			Gamecontroller = null;
		}

		if (Gamecontroller != null && Gamecontroller.GetComponent<GameController>().pos != Vector3.zero)
		{

			this.transform.position = Gamecontroller.GetComponent<GameController>().pos; //+ new Vector3(0, 6, 0);
			ddjump_allowed = Gamecontroller.GetComponent<GameController>().item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "double_jump")];

		}

		/*fireSword.SetActive(false);


		thundersword.SetActive(false);*/
		controller = GetComponent<CharacterController>();

		
		// on cree une nouvelle barre de vie et d'apnee 

		Barredevie = new healthBarre();


     	if (Gamecontroller != null)
		{
			life = Gamecontroller.GetComponent<GameController>().life;
			Barredevie.max = life;
			Barredevie.valeur = life;
		}
		else
		{
			
			Barredevie.max = life;
            Barredevie.valeur = life;
        }
	}

	// Update is called once per frame
	void Update()
	{



		// mouvements de player 
		if (controller.isGrounded)// le player est il a sol 
		{
			onground = true;
			verticalVelocity -= gravity * Time.deltaTime;
			Jump = false; // l'aniamtion saut n'as pas besoin d'etre jouée 

			ddjump = true; // le double jump est de nouveau possible 

			
			
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

			if (Input.GetAxis("Horizontal2") > 0.5 || Input.GetAxis("Horizontal2") < -0.5)
			{
				transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal2") * Time.deltaTime * sensibility, 0f));
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

			if (Input.GetKeyDown("joystick button 0")) // si le joueur appuis sur la touche x le personnage vas sauter;
			{
				verticalVelocity = jumpForce;


			}

			moveVector = new Vector3(0, 0, Input.GetAxis("Vertical") * Speed); // le deplacement du joueur 

			moveVector = transform.TransformDirection(moveVector);




		}
		else // le joueur n'est pas au sol
		{
			onground = false;
			if (Input.GetKeyDown("joystick button 0") && ddjump_allowed && ddjump) // si le joueur appuis sur la touche x le personnage vas sauter;
			{

				verticalVelocity = jumpForce;
				ddjump = false;
				//moveVector.y = jumpForce;

			}
			verticalVelocity -= gravity * Time.deltaTime;
			walk = false;
		}


		




		transform.RotateAround(Third_Camera.transform.position, Vector3.up, Input.GetAxis("Horizontal") * rotatespeed * Time.deltaTime);//la rotation se fait autour de la camera 




		moveVector = Vector3.zero;

		moveVector.y = verticalVelocity; // on applique la gravitée au joueur 
		moveVector.z = Input.GetAxis("Vertical") * Speed;
		moveVector = transform.TransformDirection(moveVector);
		controller.Move(moveVector * Time.deltaTime); // on effectue les deplacements
		if (Game_controller_script != null)
		{
			Game_controller_script.pos = transform.position;
		}
		
		



	}

	private void getHit(int nb)
	{

		life -= nb;
		Barredevie.valeur -= 1;
		Game_controller_script.life = life;

	}





}
