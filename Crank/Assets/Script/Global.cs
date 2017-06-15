using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Global : MonoBehaviour {


	// Gameoject utilisés par Global
	public GameObject player;
	public GameObject enemy;
	public GameObject[] enemys;
	public GameObject coins;
	//argent du joueur 
	public GameObject desthimg;
	public bool enemy_active = false;
	// list des Enemy crer par GLobal;
	public  List<GameObject> Enemys;
	public Transform spawnpoint;
	public bool Playeralive = true;
	// Use this for initialization
	void Start ()
	{
		
		
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enemy_active == true)
		{
			foreach (GameObject h in enemys)
			{
				h.SetActive(true);
			}
			
		}
		foreach (GameObject  h in enemys)
		{
			if (!h.activeInHierarchy)
			{
				/*print(h);
				Timer time = new Timer();
				time.Reactivate(h, 10);*/
				StartCoroutine(respawn(h));

			}
		}
		if (!Playeralive)
		{
			player.SetActive(false);
			desthimg.SetActive(true);
		}
	}
	public IEnumerator respawn(GameObject h)
	{
		yield return new WaitForSeconds(30);
		h.SetActive(true);
	}
	


	






	
	
}
