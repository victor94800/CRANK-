using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Global : MonoBehaviour {

	
	// Gameoject utilisés par Global
	GameObject enemy;



	//argent du joueur 
	public int Money;
	public Text moneytext;

	// list des Enemy crer par GLobal;
	public static List<GameObject> Enemys;


	// Use this for initialization
	void Start ()
	{
		
		enemy = GameObject.Find("Enemy");

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}



	




	public class AI
	{
		int type;
		GameObject Enemy = new GameObject();
		int life;
		int damage;
		List<GameObject> target;
		public AI(int type , int life , int damage , GameObject T , List<GameObject> target = null)
		{
			Enemy = T;
			Enemys.Add(Enemy);
			this.life = life;
			this.damage = damage;
			this.type = type;
			this.target = target;
		}
		public void AddiAcomponent()
		{
			switch (type)
			{
				case 0 :
					Enemy.AddComponent<ParcourIA>();
					ParcourIA l = new ParcourIA();
					l = Enemy.GetComponent<ParcourIA>();
					l.life = life;
					l.Damage = damage;
					l.target = target;
					break;
				case 1:
					notMovingIA T = new notMovingIA();
					Enemy.AddComponent<notMovingIA>();
					T = Enemy.GetComponent<notMovingIA>();
					T.Damage = damage;
					T.life = life;
					break;
				case 2:
					IA h = new IA();
					Enemy.AddComponent<IA>();
					h = Enemy.GetComponent<IA>();
					h.life = life;
					h.Damage = damage;

					break;
				default:
					break;

			}
		}
	}
}
