using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minotaur : MonoBehaviour {

	// Use this for initialization
	public GameObject Player;
	public int life;
	private Vector3 Dirtomain;
	public bool CanAttack;
	Animator anim;
	NavMeshAgent agent;
	public bool attack;
	public bool Walk;
	AudioClip attak;
	AudioClip walk;
	void Start()
	{

		Dirtomain = Player.transform.position - transform.position;
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{
		if (life == 0)
		{
			agent.Stop();
			anim.SetBool("die", true);
			StartCoroutine(death());
		}
		Dirtomain = Player.transform.position - transform.position;
		if (Dirtomain.magnitude < 10)
		{
			agent.destination = Player.transform.position;
		}
		if (Dirtomain.magnitude < 3)
		{
			CanAttack = true;

		}
		else
		{
			CanAttack = false;
		}
		if (CanAttack)
		{
			if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
			{

				agent.Stop();
				Walk = false;
				attack = true;



			}
			else
			{
				attack = false;
			}
		}
		else if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
		{

			agent.Resume();

			if (agent.velocity != Vector3.zero)
			{
				Walk = true;

			}
			attack = false;


		}

		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
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

		anim.SetBool("attack", attack);
		anim.SetBool("walk", Walk);

	}
	public void getHit(int nb)
	{

		life -= nb;


	}
	public IEnumerator death()
	{
		yield return new WaitForSeconds(5f);
		Destroy(gameObject);
	}
}
