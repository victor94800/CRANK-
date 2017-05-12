using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Global : MonoBehaviour {

	
	// Gameoject utilisés par Global
	public GameObject enemy;
	public GameObject[] enemy_path;
	public GameObject[] enemy_path_2;
	public GameObject[] enemy_path_3;
	public GameObject[] enemy_path_4;
	public GameObject[] enemy_path_5;
	public GameObject[] enemy_path_6;

	public GameObject[] enemy_path_7;
	public GameObject[] enemy_path_8;
	public GameObject[] enemy_path_9;
	public GameObject[] enemy_path_10;
	public GameObject coins;
	//argent du joueur 
	
	public bool enemy_active = false;
	// list des Enemy crer par GLobal;
	public  List<GameObject> Enemys;


	// Use this for initialization
	void Start ()
	{
		
		
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enemy_active == true)
		{
			GameObject IA = GetComponent<IACreator>().InstentiateIA(0, transform.rotation, enemy, enemy_path);
			enemy_active = false;
			print(IA);
			Enemys.Add(IA);
			
		}
		foreach (GameObject  h in Enemys)
		{
			if (!h.activeInHierarchy)
			{
				StartCoroutine(respawn(h));

			}
		}

	}
	public IEnumerator respawn(GameObject h)
	{
		yield return new WaitForSeconds(10);
		h.SetActive(true);
	}


	






	
	
}
