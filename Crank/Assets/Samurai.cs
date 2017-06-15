using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Samurai : MonoBehaviour {
	// Use this for initialization
	public GameObject Player;
	public int life;
	private Vector3 Dirtomain;
	public bool CanAttack;
	Animation anim;
	NavMeshAgent agent;
	public bool attack;
	public bool Walk;
	AudioClip attak;
	AudioClip walk;
	void Start()
	{

		Dirtomain = Player.transform.position - transform.position;
		anim = GetComponent<Animation>();
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{
		if (life == 0)
		{
			agent.Stop();
			
			StartCoroutine(death());
		}
		
		Dirtomain = Player.transform.position - transform.position;
		Dirtomain.y = 0;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Dirtomain), 100);
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
			if (!anim.IsPlaying("Attack"))
			{

				agent.Stop();
				Walk = false;
				attack = true;
				anim.CrossFade("Attack");


			}
			else
			{
				attack = false;
			}
		}
		else if (!anim.IsPlaying("Attack"))
		{

			agent.Resume();

			if (agent.velocity != Vector3.zero)
			{
				Walk = true;
				anim.CrossFade("Walk");
			}
			attack = false;


		}

		

		
	}
	public void getHit(int nb)
	{

		life -= nb;


	}
	public IEnumerator death()
	{
		yield return new WaitForSeconds(5f);
		gameObject.SetActive(false);
	}
}
