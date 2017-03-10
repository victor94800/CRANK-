using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private bool Run;
    private float inputH;
    private float inputV;
    public Animator anim;
    public Rigidbody rbody;
    private bool Jump;
    public  bool attack;
    private bool Attack;
    private bool Attack1;
    

    // Use this for initialization
    void Start () {
        //animateur 
        anim = GetComponent<Animator>();
        // rigidbody 
        rbody = GetComponent<Rigidbody>();
        Run = false;
        Jump = false;
        Attack = false;
        Attack1 = false;
        attack = Attack || Attack1;
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetKey("joystick button 0"))
        {
            Jump = true;
        }
        else
        {
            Jump = false;
        }
        if (Input.GetKey("joystick button 2"))
        {

            Attack = true;
            attack = Attack ;
        }
        else
        {
            Attack = false;
            attack = Attack ;
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
            Attack1 = true;
            attack = Attack || Attack1;
        }
        else
        {
            Attack1 = false;
            attack = Attack || Attack1;
        }
        attack = Attack || Attack1;
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
       
    
        anim.SetFloat("InputH", inputH);
        anim.SetFloat("InputV", inputV);
        anim.SetBool("Run", Run);
        anim.SetBool("Jump", Jump);
        anim.SetBool("Attack", Attack);
        anim.SetBool("Attack1", Attack1);

       
        float moveZ = inputV * 5f * Time.deltaTime;
        float moveX = inputH * 100f * Time.deltaTime;
        
        if (Run)
        {
            anim.speed = 3;
           
            moveZ *= 3f;
        }
        else
        {
            anim.speed = 1;
        }
        if (Jump)
        {
            anim.speed = 0.5f;
            rbody.velocity = new Vector3(0, 30f, 0);
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
        rbody.velocity = new Vector3(0, -10f, 0);
        transform.Translate(new Vector3(0, 0, moveZ));
        transform.Rotate(new Vector3(0, moveX, 0));
        
    }
}
