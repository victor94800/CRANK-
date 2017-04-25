using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notMovingIA : MonoBehaviour
 {
// atribut de l'IA
	public int life;
	public int Damage;
	private Animation anim;

// gameobject utilisés par l'ia 
	public GameObject COINS;
	Quaternion rtn;

// player information
	Vector3 dirtomain; // distance entre l'ia et le joueur

// bolleens relatif aux actions que l'ia peut effectuées
	public bool Attack = false;
	public CharacterController cc;
	private Vector3 mouvevector;
	public float gravity = 40f;
	//public static Vector3 pos;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animation>();
		cc = GetComponent<CharacterController>();
		// intitailistaton des attribut ou des objets utilisés par l'IA 
		rtn = COINS.transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		mouvevector = Vector3.zero;
		// actualisation de dirtomain
		dirtomain = GameObject.Find("player").transform.position - transform.position;

		// verifie si L'ia est toujour en vie 
		if (life <= 0 )
		{   
			// creer un nombre de pieces aleatoire entre 2 et 7  avnt de faire disparaitre l'enemy 
			int nbcoins  = Random.Range(2, 7);
			for (int i = 0; i < nbcoins; i++)
			{

				Vector3 pos = Random.insideUnitSphere * 5 + this.gameObject.transform.position;
				Transform newGameObj = Instantiate(COINS.transform, pos, rtn) as Transform;
			}

			// detruit l'objet enemy
			this.gameObject.SetActive(false);
		}
	// verifie si l'ia peut attaquer le joueur
		if (dirtomain.magnitude < 2)
		{
			Attack = true;
			anim.CrossFade("Attack_1");
		}
		else
		{
			Attack = false;
			anim.CrossFade("Idle");
		}

		mouvevector.y -= gravity * Time.deltaTime;
		cc.Move(mouvevector * Time.deltaTime);
	}
	private void getHit(int nb)
	{

		life -= nb;

	}


}
