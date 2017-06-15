using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PunchAi : MonoBehaviour
{
	public AudioClip walk;
	public AudioClip attak;
	public float time;
	public GameObject COINS;
	Quaternion rtn;
	public Vector3 pos;
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
	public bool lookat;
	// Use this for initialization
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animation>();
	}

	// Update is called once per frame
	void Update()
	{
		if (lookat)
		{
			dirtomain.y = 0;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 100);
		}
		dirtomain = Player.position - transform.position;
		if (GetComponent<AIController>().life <= 0)
		{
			StartCoroutine(Die());
		}
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
				GetComponent<AudioSource>().PlayOneShot(attak);
				fixedtime = Time.fixedTime;

			}
		}
		else if (!anim.IsPlaying("Attack_1"))
		{

			agent.Resume();

			if (agent.velocity != Vector3.zero)
			{
				anim.CrossFade("Run");
				GetComponent<AudioSource>().PlayOneShot(walk);
				attack = false;
			}
			else
			{
				anim.CrossFade("Idle");
				attack = false;
			}
		}

		
			/*if (attack)
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
			}*/

		
	}
	private IEnumerator Die()
	{
		yield return new WaitForSeconds(2);
		money();

	}
	public void money()
	{
		int nbcoins = Random.Range(2, 7);
		for (int i = 0; i < nbcoins; i++)
		{

			pos = Random.insideUnitSphere * 5 + this.gameObject.transform.position;
			Transform newGameObj = Instantiate(COINS.transform, pos, Quaternion.identity) as Transform;
		}
		gameObject.SetActive(false);
	}
}
