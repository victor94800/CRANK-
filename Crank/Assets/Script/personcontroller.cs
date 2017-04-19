using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personcontroller : MonoBehaviour {
    private CharacterController controller;
    private bool beingHandled = false;
    private float verticalVelocity;
    public float gravity = 10.0f;
    public float jumpForce = 5000.0f;
    public float speed = 10;
	public float runspeed = 20;
    private Vector3 moveVector = new Vector3();
	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
		

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown("joystick button 0") )
            {
                verticalVelocity = jumpForce  ;
            }

        }
        else
        {
            verticalVelocity = -gravity * Time.deltaTime;

        }
		if  (Input.GetKeyDown("joystick button 5"))
		{
			//moveVector = new Vector3(0, 0, Input.GetAxis("Vertical") * runspeed);
		}
		else
		{
			//moveVector = new Vector3(0, 0, Input.GetAxis("Vertical") * speed);
		}
		moveVector = transform.TransformDirection(moveVector);
        
        //transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal")*Time.deltaTime*100 , 0));
        moveVector.y = verticalVelocity;
        controller.Move(moveVector * Time.deltaTime); 
		
	}
	
  
}
