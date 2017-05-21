using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcourIA : MonoBehaviour {
	// parcour et ses attributs
	public GameObject[]  target;
	int i = 0;
	public Transform thui;
	Transform tt; // target transform 
	public float gravity;
	// atribut de l'IA
	public int life;
	public int Damage;
	
	Animation anim;
	// gameobject utilisés par l'ia 
	public GameObject COINS;
	Quaternion rtn;

	// player information
	Vector3 dirtomain; // distance entre l'ia et le joueur
	

	// bolleens relatif aux actions que l'ia peut effectuées
	public bool Attack = false;
	public bool ismoving;
	private bool follow = false;

	public Vector3 mouvevector;
	public Vector3 dirtomain_target;
	private CharacterController cc;
	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animation>();
		
		// intitailistaton des attribut ou des objets utilisés par l'IA 
		rtn = COINS.transform.rotation;
		mouvevector = Vector3.zero;
		cc = GetComponent<CharacterController>();
		gravity = 40;
	}

	// Update is called once per frame
	void Update()
	{

		mouvevector = Vector3.zero;
		// actualisation de dirtomain
		dirtomain = GameObject.Find("Player").transform.position - transform.position;
		

		// verifie si L'ia est toujour en vie 
		if (life <= 0)
		{
			// creer un nombre de pieces aleatoire entre 2 et 7  avnt de faire disparaitre l'enemy 
			int nbcoins = Random.Range(2, 7);
			for (int i = 0; i < nbcoins; i++)
			{

				Vector3 pos = Random.insideUnitSphere * 5 + this.gameObject.transform.position;
				Instantiate(COINS, pos, rtn);
			}

			// detruit l'objet enemy
			this.gameObject.SetActive(false);
		}
		
		
		// deplacement de l'ia 

		if (dirtomain.magnitude <= 3)
		{
			follow = true;
		}
		else
		{
			follow = false;
		}
		if (follow == false)// deplacement normal
		{
			if (i >= target.Length )
				i = 0;
			
			dirtomain_target = target[i].transform.position - transform.position;
			dirtomain_target.y = 0;
			mouvevector = dirtomain_target * 0.2f;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain_target), 10f);
			if (dirtomain_target.magnitude <= 10)
			{
				// changement de direction
				i += 1;
			}
			// verifie si l'ia peut attaquer le joueur
			if (dirtomain.magnitude < 1.5)
			{
				Attack = true;
			}
			else
			{
				Attack = false;
			}
		}
		else // deplacement en suivant le joueur 
		{
			
			mouvevector = dirtomain * 0.4f;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 10f);
			// verifie si l'ia peut attaquer le joueur
			if (dirtomain.magnitude < 1.5)
			{
				
				Attack = true;
				anim.CrossFade("Attack_1");
			}
			else
			{
				Attack = false;
				anim.CrossFade("Run");
			}
		}
		
		//mouvevector = transform.TransformDirection(mouvevector);
		mouvevector.y -= gravity * Time.deltaTime;
		cc.Move(mouvevector * Time.deltaTime);

	}
	// inflige des domage a l'ia 
	private void getHit(int nb)
	{

		life -= nb;
		

	}
	// verifie si l'ia doit suivre le joueur 
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "Player")
		{
			follow = true;
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.transform.name == "Player")
		{
			follow = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		follow = false;
	}

}
