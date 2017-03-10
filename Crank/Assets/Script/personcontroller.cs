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
            if (Input.GetKey("joystick button 0") )
            {
               // GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
                verticalVelocity = jumpForce;
            }

        }
        else
        {
            verticalVelocity = -gravity * Time.deltaTime;

        }
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal")* speed;
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") , 0));
        moveVector.y = verticalVelocity;
        moveVector.z = Input.GetAxis("Vertical")* speed;
        
        controller.Move(moveVector * Time.deltaTime); 
		
	}
  
}
