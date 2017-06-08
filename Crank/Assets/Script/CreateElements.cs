using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateElements : MonoBehaviour {
	public GameObject parent;
	public Transform position;
	// Use this for initialization

	


	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.I))
		{
			Instantiate(parent, position.position , Quaternion.identity); 
		}
		
	}
}
/*how to use it : 
 *this script create an instance of an objetc when you press the key i allwright you can change this key in the if keycode.""" 
 *Don't forget to give the parent the object that you want to create the instance and the transform of the position of where you want to create the copy of this game object
 *you can also use this script for creat  path of empty
 */
