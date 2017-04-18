using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	// attribut de player 
	private CharacterController controller;

	// action  de player 
	private bool Attack = false;
	private bool Attack1 = false;
	
	// deplacemtn de player
	private bool Run = false ;
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
	public float gravity = 10.0f;
	public float jumpForce = 5000.0f;
	public float speed = 10;
	public float runspeed = 20;

	// game object associer a player
	GameObject sword;
	GameObject thundersword;
	GameObject fireSword;


	// autres 
	double time;
	double time2;

	// capacites de player a debloquer
	private bool TunderSword_allowed  = false;
	private bool fireSword_allowed = false;
	private bool ddjump_allowed = false ;
	
	
	
	
	
	
    // Use this for initialization
	void Start ()
	{
		// initialisation dest component de player 
		controller = GetComponent<CharacterController>();
		
		//animateur 
		anim = GetComponent<Animator>();

		
        // initialisation des objets associés a player 
        sword = GameObject.Find("PlayerS") ;

		fireSword = GameObject.Find("firesword");
		fireSword.SetActive(false);

		thundersword = GameObject.Find("thundersword");
		thundersword.SetActive(false);

        
    }
	
	// Update is called once per frame
	void Update ()
    {
		// update de controller 
		controller = GetComponent<CharacterController>();
		
		//actions 
		if (anim.GetTime() >= time + 0.20f )
        {
           
            Attack = false;
            Attack1 = false;
            sword.GetComponent<BoxCollider>().enabled = false;
           
        }
      
        if (Input.GetKey("joystick button 2"))
        {
            sword.GetComponent<BoxCollider>().enabled = true;
            time = anim.GetTime();
            Attack = true;
           
        }
        if (Input.GetKey("joystick button 5"))
        {
            Run = true;
			

        }
        else
        {
            Run = false;
			
			
        }
        if (Input.GetKey("joystick button 3"))
        {
            sword.GetComponent<BoxCollider>().enabled = true;

            Attack1 = true;
            time = anim.GetTime();

        }
      
        // gestion de l'animation en fonction des actions de player 
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetFloat("InputH", inputH);
        anim.SetFloat("InputV", inputV);
        anim.SetBool("Run", Run);
        anim.SetBool("Jump", Jump);
        anim.SetBool("Attack", Attack);
        anim.SetBool("Attack1", Attack1);

       //animation
       
        if (Run)
        {
            anim.speed = 2;
			

		}
        else
        {
            anim.speed = 1;
			
		}
        if (Jump)
        {
            anim.speed = 0.5f;
            
        }
        else if (!Run)
        {
            anim.speed = 1f;
        }
        if (Attack)
        {
            anim.speed = 2;
        }
        else if (!Run)
        {
            anim.speed = 1;
        }
		
		// mouvements de player 
		if (controller.isGrounded)// le player est il a sol 
		{
			Jump = false; // l'aniamtion saut n'as pas besoin d'etre jouée 
			anim.SetBool("is grounded", true); // le booleen is grounded de l'animator et mis a true 
			dubble_jump = true; // le double jump est de nouveau possible 

			if (Run) // le joueur est il en train de courrir 
			{
				Speed = runspeed;
			}
			else
			{
				Speed = speed;
			}

			transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * Time.deltaTime * 100, 0)); // la rotaion de joueur

			moveVector = new Vector3(0, 0, Input.GetAxis("Vertical")); // le deplacement du joueur 

			moveVector = transform.TransformDirection(moveVector);

			moveVector *= Speed; // on applique la vitesse de deplacements 

			if (Input.GetKeyDown("joystick button 0")) // si le joueur appuis sur la touche x le personnage vas sauter;
			{
				moveVector.y = jumpForce;
				Jump = true;
			}

		}
		else // le joueur est en l'air 
		{
			

			if (ddjump_allowed == true && dubble_jump == true)
			{
				
				if (Input.GetKeyDown("joystick button 0")) // il fait un double saut  
				{
					moveVector.y = jumpForce;
					dubble_jump = false;
					Jump = true;
				}
			}
		}
		
		moveVector.y -= gravity * Time.deltaTime; // on applique la gravitée au joueur 
		controller.Move(moveVector * Time.deltaTime); // on effectue les deplacements 
		
		

		
		
	}
}
