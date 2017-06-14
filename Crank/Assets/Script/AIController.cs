using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
	public static int IAWhoseePLayer; // est -ce qu'une ia est en train de voir le joueur 

	public GameObject path;
	public Transform Player;
	private NavMeshAgent Agent;
	private GameObject[] Waypoints;
	private GameObject eyes;
	// 
	public bool lookatplayer;
		

	private Vector3 Dirtomain;
	// 
	int Index = 1;

	
	//
	bool moving;

	public bool IS_Following_PLayer;
	public int life;
	
	// Use this for initialization
	void Start ()
	{
		Agent = GetComponent<NavMeshAgent>();
		
		
		if (Player == null )
		{
			try
			{
				Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
				Dirtomain = Player.position - transform.position;
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
					Waypoints[i] = path.transform.GetChild(i).gameObject;
				}
				Agent.destination  = Waypoints[Index].transform.position;
				print( Waypoints[Index]);
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
		if (IS_Following_PLayer == true)
		{
			Agent.destination = Player.position;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Dirtomain), 100);
		}
		Dirtomain = Player.position - transform.position;
		if (path != null)
		{
			if (IAWhoseePLayer > 0 && Dirtomain.magnitude < 20)
			{
				IS_Following_PLayer = true;
				IAWhoseePLayer += 1;
			}
			if (Dirtomain.magnitude > 20 || !GameObject.Find("Global").GetComponent<Global>().Playeralive)
			{
				IS_Following_PLayer = false;
				IAWhoseePLayer -= 1;
				Agent.destination = Waypoints[Index].transform.position;
				if (!GameObject.Find("Global").GetComponent<Global>().Playeralive)
				{
					IAWhoseePLayer = 0;
				}
			}
			
			
				if (Agent.destination.magnitude == 0 && !IS_Following_PLayer)
				{
					Index += 1;
					Agent.destination = Waypoints[Index].transform.position;
					
				}
			
		}

		

		
	}
	private void SetSpeed(float speed)
	{
		Agent.speed = speed;
	}
	private void SetStoppingDistance(float stop_dist)
	{
		Agent.stoppingDistance = stop_dist;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "PLayer")
		{
			IS_Following_PLayer = true;
		}
	}
	public void Folowing()
	{
		IS_Following_PLayer = true;
	}
	public void getHit(int nb)
	{

		life -= nb;
		

	}

}
