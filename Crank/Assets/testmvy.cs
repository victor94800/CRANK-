using UnityEngine;
using System.Collections;

public class testmvy : MonoBehaviour
{

	public Transform target;
	public float speed = 360f;    // speed in degrees per second 
	public float gravity = 10f; // gravity, if you want to use it
	CharacterController character;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void LateUpdate()
	{
		RotateChar();
	}

	// call this function in LateUpdate
	void RotateChar()
	{
		// make sure the variable "character" contains the controller: 
		if (!character)
			character = transform.GetComponent<CharacterController>();
		// curPos = vector from target to character: 
		Vector3 curPos = transform.position - target.position;
		// rotate curPos by the appropriate angle and save in newPos: 
		Vector3 newPos = Quaternion.Euler(0, speed * Time.deltaTime, 0) * curPos;
		// calculate the displacement to move 
		Vector3 displacement = newPos - curPos;
		// if you don't need gravity, comment out this line: 
		//displacement -= gravity*Vector3.up*Time.deltaTime*Time.deltaTime; 
		character.Move(displacement);
		// move by the distance calculated 
		transform.LookAt(target);
		// keep looking to the target 

		Debug.Log(Vector3.Distance(target.position, transform.position));
	}
}


