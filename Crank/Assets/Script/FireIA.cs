using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireIA : MonoBehaviour {
	public float time;
	public GameObject COINS;
	Quaternion rtn;
	public Vector3 pos;
	public int i = 1;
 	public bool attack;
	public GameObject bullet;
	public float Speed;
	public float distance;
	public Animation anim;
	public GameObject luncher;
	private float fixedtime;
	private NavMeshAgent agent;
	// Use this for initialization
	public bool CanAttack;
	public Transform Player;
	static bool isplayerdead = false;
	Vector3 dirtomain;
	Global Global;
	public bool die;
	void Start ()
	{
		fixedtime = Time.fixedTime;
		agent = GetComponent<NavMeshAgent>();
		Global = GameObject.Find("Global").GetComponent<Global>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<AIController>().life <= 0)
		{
			if (die)
			{
				return;
			}
			anim.CrossFade("Death_1");
			StartCoroutine(Die());
			die = true;
		}
		isplayerdead = !Global.Playeralive;
		
			dirtomain = GameObject.Find("visé").transform.position - transform.position;
			if (dirtomain.magnitude < 10 && !isplayerdead && GetComponent<AIController>().IS_Following_PLayer)
			{
				CanAttack = true;

			}
			else
			{
				CanAttack = false;
			}
			if (CanAttack || anim.IsPlaying("Attack_1") && !isplayerdead)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 100);
				if (!anim.IsPlaying("Attack_1"))
				{

					agent.Stop();
					attack = true;
					anim.CrossFade("Attack_1");
					fixedtime = Time.fixedTime;

				}

				if (Time.fixedTime >= fixedtime + time && attack && !isplayerdead)
				{
					//agent.Resume();
					Fire.fire(bullet, luncher.transform.position, transform, luncher.transform.rotation, dirtomain, Speed, distance);
					attack = false;
				}
			}
			else if (!anim.IsPlaying("Attack_1"))
			{

				agent.Resume();

				if (agent.velocity != Vector3.zero)
				{
					anim.CrossFade("Run");
				}
				else
				{
					anim.CrossFade("Idle");
				}
			}
		
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
		GetComponent<AIController>().life = 60;
		die = false;
		gameObject.SetActive(false);
	}

}
