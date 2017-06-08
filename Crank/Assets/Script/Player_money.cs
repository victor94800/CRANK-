using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_money : MonoBehaviour {
    public int Money;
    public Text moneytext;

	//controller
	public GameObject Gamecontroller;
	public GameController Game_controller_script;
    // Use this for initialization
    void Start ()
	{

		try
		{
			Gamecontroller = GameObject.Find("GameController");
			Game_controller_script = Gamecontroller.GetComponent<GameController>();
		}
		catch
		{
			Gamecontroller = null;
		}
		if (Gamecontroller != null)
		{
			Money = Gamecontroller.GetComponent<GameController>().money;
			moneytext.text = Money.ToString();
		}
		else
		{
			Money = 0;
			moneytext.text = Money.ToString();
		}
		//moneytext.text = "money :" + Money.ToString();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//moneytext.text = Money.ToString();
	}
    public void AddMoney(int a)
    {
        Money += a;
        moneytext.text = Money.ToString();
		Game_controller_script.money = Money;


	}
	public void lossMOney(int a)
	{
		Money -= a;
		moneytext.text = Money.ToString();
		Game_controller_script.money = Money;
	}
}
