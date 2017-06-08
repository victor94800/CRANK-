using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PunchAi : MonoBehaviour
{
	public AudioClip walk;
	public AudioClip attak;
	public float time;

	public int i = 1;
	public bool attack;

	public float Speed;
	public float distance;
	public Animation anim;

	private float fixedtime;
	private NavMeshAgent agent;
	// Use this for initialization
	public bool CanAttack;
	public Transform Player;

	Vector3 dirtomain;

	// Use this for initialization
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animation>();
	}

	// Update is called once per frame
	void Update()
	{
		dirtomain = Player.position - transform.position;
		
		if (dirtomain.magnitude < 3)
		{
			CanAttack = true;

		}
		else
		{
			CanAttack = false;
		}
		if (CanAttack || anim.IsPlaying("Attack_1"))
		{
			if (!anim.IsPlaying("Attack_1"))
			{

				agent.Stop();
				attack = true;
				anim.CrossFade("Attack_1");
				fixedtime = Time.fixedTime;

			}
		}
		else if (!anim.IsPlaying("Attack_1"))
		{

			agent.Resume();

			if (agent.velocity != Vector3.zero)
			{
				anim.CrossFade("Run");
				attack = false;
			}
			else
			{
				anim.CrossFade("Idle");
				attack = false;
			}
		}

		if (!anim.IsPlaying("Attack_1"))
		{
			if (attack)
			{
				if (!GetComponent<AudioSource>().isPlaying)
				{
					GetComponent<AudioSource>().Stop();
					GetComponent<AudioSource>().PlayOneShot(attak);
				}
			}
			else
			{
				if (!GetComponent<AudioSource>().isPlaying)
				{
					GetComponent<AudioSource>().Stop();
					GetComponent<AudioSource>().PlayOneShot(walk);
				}
			}

		}
	}
}
