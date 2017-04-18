using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcourIA : MonoBehaviour {
	// parcour et ses attributs
	public List<GameObject>  target;
	int i = 0;
	Transform tt; // target transform 

	// atribut de l'IA
	public int life;
	public int Damage;
	public Vector3 pos; 

	// gameobject utilisés par l'ia 
	public GameObject COINS;
	Quaternion rtn;

	// player information
	Vector3 dirtomain; // distance entre l'ia et le joueur
	Transform pt;

	// bolleens relatif aux actions que l'ia peut effectuées
	private bool Attack = false;
	private bool follow = false;

	//public static Vector3 pos;

	// Use this for initialization
	void Start()
	{
		// intitailistaton des attribut ou des objets utilisés par l'IA 
		rtn = COINS.transform.rotation;
	}

	// Update is called once per frame
	void Update()
	{
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
				Transform newGameObj = Instantiate(COINS.transform, pos, rtn) as Transform;
			}

			// detruit l'objet enemy
			this.gameObject.SetActive(false);
		}
		
		
		// deplacement de l'ia 

		
		if (follow == false)// deplacement normal
		{
			if (i >= target.Count)
				i = 0;
			tt = GameObject.Find(target[i].name).transform;
			pos = GameObject.Find(target[i].name).transform.position - transform.position;
			transform.position = Vector3.Lerp(transform.position, tt.position, 0.05f);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), 10f);
			if (pos.magnitude <= 2)
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
			pt = GameObject.Find("Player").transform;
			transform.position = Vector3.Lerp(transform.position, pt.position, 0.05f);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 10f);
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
