using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireIA : MonoBehaviour {
	public float time;
	public GameObject[] target;
	public int i = 1;
 	public bool attack;
	public GameObject bullet;
	public int Speed;
	public int distance;
	public Animation anim;
	public GameObject luncher;
	private float fixedtime;
	private NavMeshAgent agent;
	// Use this for initialization
	void Start ()
	{
		fixedtime = Time.fixedTime;
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(target[i].transform.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 dirtomain = agent.destination - transform.position;
		print(agent.destination);
		if (dirtomain.magnitude <= 4)
		{
			i += 1;
			if (i >= target.Length)
			{
				i = 0;
			}
			agent.SetDestination(target[i].transform.position);
		}
		if(!anim.isPlaying )
		{
			attack = true;
			anim.CrossFade("Attack_1");
			fixedtime = Time.fixedTime;
			
		}
		if (Time.fixedTime >= fixedtime + time && attack)
		{
			Fire.fire(bullet, luncher.transform.position, luncher.transform, Speed, distance);
			attack = false;
		}
	}
	
	
}
