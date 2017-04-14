using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private bool Run;
	public float Speed;
    private float inputH;
    private float inputV;
    public Animator anim;
    private bool Jump;
    private bool Attack;
    private bool Attack1;
    double time;
	double time2;
	GameObject sword;
	private CharacterController controller;
	private float verticalVelocity;
	public float gravity = 10.0f;
	public float jumpForce = 5000.0f;
	public float speed = 10;
	public float runspeed = 20;
	private Vector3 moveVector = Vector3.zero;
	public bool dubble_jump;
	private bool ddjump = false;
    // Use this for initialization
	void Start ()
	{
		dubble_jump = true;
		controller = GetComponent<CharacterController>();
		//animateur 
		anim = GetComponent<Animator>();
		Run = false;
        Jump = false;
        Attack = false;
        Attack1 = false;
        sword = GameObject.Find("PlayerS") ;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
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
		

		if (controller.isGrounded)
		{
			Jump = false;
			anim.SetBool("is grounded", true);
			dubble_jump = true;

			if (Run)
			{
				Speed = runspeed;
			}
			else
			{
				Speed = speed;
			}
			transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * Time.deltaTime * 100, 0));
			moveVector = new Vector3(0, 0, Input.GetAxis("Vertical"));
			moveVector = transform.TransformDirection(moveVector);
			moveVector *= Speed;
			if (Input.GetKeyDown("joystick button 0"))
			{
				moveVector.y = jumpForce;
				Jump = true;
			}

		}
		else
		{
			if (Global.dubblejump_allowed == true && dubble_jump == true)
			{
				if (Input.GetKeyDown("joystick button 0"))
				{
					moveVector.y = jumpForce;
					dubble_jump = false;
					Jump = true;
				}
			}
		}

		moveVector.y -= gravity * Time.deltaTime;
		controller.Move(moveVector * Time.deltaTime);
		
		

		
		
	}
}
