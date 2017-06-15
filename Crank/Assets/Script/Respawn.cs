using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public GameObject global;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void respawn()
	{
		player.GetComponent<PlayerController>().life = 100;
<<<<<<< HEAD
		player.GetComponent<PlayerController>().respawn();
=======
>>>>>>> master
		player.transform.position = global.GetComponent<Global>().spawnpoint.position;
		global.GetComponent<Global>().Playeralive = true;
		
	switch(	player.GetComponent<PlayerController>().playertype)
			
		{
			case 0:
				GameObject.FindWithTag("Player").GetComponent<Warior>().die = false;
				break;
			case 1:
				GameObject.FindWithTag("Player").GetComponent<Jimmy>().die = false;
				break;
			case 2:
				GameObject.FindWithTag("Player").GetComponent<Golem>().die = false;
				break;
			default:
				break;
		}
		AIController.IAWhoseePLayer = 0;
		player.SetActive(true);
		gameObject.SetActive(false);
		
		
	}
}
