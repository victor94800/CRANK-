using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
	public GameObject M1;
	public GameObject M2;
	public GameObject M3;
	public GameObject GameController;
	// Use this for initialization
	void Start ()
	{
		try
		{
			GameController = GameObject.Find("GameController");
			
			
			if (GameController.GetComponent<GameController>().mission == 0)
			{
				M1.SetActive(true);
				
			}
			else if (GameController.GetComponent<GameController>().mission == 1)
			{
				M2.SetActive(true);

			}
			else if (GameController.GetComponent<GameController>().mission == 2)
			{
				M3.SetActive(true);

			}
		}
		catch
		{
			M1.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameController != null)
		{
			if (GameController.GetComponent<GameController>().mission == 0)
			{
				M1.SetActive(true);

			}
			else if (GameController.GetComponent<GameController>().mission == 1)
			{
				M2.SetActive(true);

			}
			else if (GameController.GetComponent<GameController>().mission == 2)
			{
				M3.SetActive(true);

			}
		}
	}
}
