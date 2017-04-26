using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Global : MonoBehaviour {

	
	// Gameoject utilisés par Global
	public GameObject enemy;
	public GameObject[] enemy_path;
	public GameObject[] enemy_path_2;
	public GameObject[] enemy_path_3;
	public GameObject[] enemy_path_4;
	public GameObject[] enemy_path_5;
	public GameObject[] enemy_path_6;

	public GameObject[] enemy_path_7;
	public GameObject[] enemy_path_8;
	public GameObject[] enemy_path_9;
	public GameObject[] enemy_path_10;
	public GameObject coins;
	//argent du joueur 
	public int Money;
	public Text moneytext;

	// list des Enemy crer par GLobal;
	public static List<GameObject> Enemys;


	// Use this for initialization
	void Start ()
	{
		
		//enemy = GameObject.Find("Enemy");
		/*for (int i = 0; i < enemy_path.Count; i ++ )
			{

			AI d = new AI(0, 50, 10, enemy, enemy_path[i]);
				
			}*/
		AI d = new AI(0, 50, 10, enemy, coins, enemy_path);

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}


	public void instanciateIA(int type, int life, int damage, GameObject T, GameObject[] target = null)
	{
		AI d = new AI(type, life, damage, T,coins,  target);
	}






	public class AI
	{
		int type;
		GameObject Enemy ;
		int life;
		int damage;
		GameObject coins;
		GameObject[]   target;
		public AI(int type , int life , int damage , GameObject T , GameObject coins ,GameObject[] target = null  )
		{
			this.coins = coins;
			Enemy = T;
			print(Enemy);
			print(T);
			//Enemys.Add(Enemy);
			this.life = life;
			this.damage = damage;
			this.type = type;
			this.target = target;
			Transform newGameObj = Instantiate(Enemy.transform, target[0].transform.position, Enemy.transform.rotation) as Transform;
			AddiAcomponent();
		}
		public void AddiAcomponent()
		{
			switch (type)
			{
				case 0 :
					//Enemy.AddComponent<ParcourIA>();
					//Enemy.GetComponent<ParcourIA>().COINS = coins;
					ParcourIA l = new ParcourIA();

					l = Enemy.GetComponent<ParcourIA>();
					l.life = life;
					l.Damage = damage;
					l.COINS = coins;
					l.target = target;
					break;
				case 1:
					notMovingIA T = new notMovingIA();
					//Enemy.AddComponent<notMovingIA>();
					T = Enemy.GetComponent<notMovingIA>();
					T.Damage = damage;
					T.life = life;
					break;
				case 2:
					IA h = new IA();
					//Enemy.AddComponent<IA>();
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
