using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour {
	public GameObject path;
	public GameObject Player;
	private NavMeshAgent Agent;
	private GameObject[] Waypoints;
	private GameObject eyes;
	// 
	public int life = 100;
	public int damages = 10;


	// 
	int Index = 1;


	//
	bool moving;
	bool IS_Following_PLayer;

	
	// Use this for initialization
	void Start ()
	{
		Agent = GetComponent<NavMeshAgent>();
		
	  	if (Player == null )
		{
			try
			{
				Player = GameObject.FindWithTag("Player");

			}
			catch
			{
				Debug.Log("WARNING : there is no PLayer == null");
			}
		}
		if (path != null)
		{
			if (path.transform.childCount > 0)
			{
				moving = true;
				Waypoints = new GameObject[path.transform.childCount];
				for (int i = 0; i < path.transform.childCount; i++)
				{
					Waypoints[i] = transform.GetChild(i).gameObject;
				}
				Agent.destination  = Waypoints[Index].transform.position;
			}
			else
			{
				moving = false;
			}
		}
		else
		{
			Debug.Log("WARNIG : there is no path to follow AI Start to move Randomly");
		}



	}
	
	// Update is called once per frame
	void Update ()
	{
		if (path != null)
		{
			if (Agent.destination.magnitude == 0 && !IS_Following_PLayer)
			{
				Index += 1;
				Agent.destination = Waypoints[Index].transform.position;
			}
		}
		else
		{
			
		}
		
	}
	

}
