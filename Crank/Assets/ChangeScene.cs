using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	public int scenenumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	private void OnTriggerStay(Collider other)
	{
		print(other.transform.tag);
		if (other.transform.tag == "PLayerController" )
		{
			if (Input.GetKeyDown("joystick button 2"))
			{
				print("test");
				SceneManager.LoadScene(scenenumber);
			}
		}
	
	}
}
