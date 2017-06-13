using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class ChangeButtonNameWhenCilck : MonoBehaviour
{
	
    public Text button1text = null;
    public Text button2text = null;
    public Text button3text = null;
    public Text button4text = null;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
	
	public int money;
    public bool ISfireswordallowed;
	public bool isthunderswordallowed;
    public bool IsSuperSnipeAllowed;
    public bool IsShieldAllowed;
    public GameObject global;

	//GAmecontroller
	public GameObject Gamecontroller;
	public GameController Game_Controller_script;
	// Use this for initialization
	void Start()
	{
		//money = 100;
		
		try
		{
			Gamecontroller = GameObject.Find("GameController");
			Game_Controller_script = Gamecontroller.GetComponent<GameController>();
			isthunderswordallowed  = Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "thunder_sword")];
			ISfireswordallowed = Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "fire_sword")];
			//IsSuperSnipeAllowed = Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "super_snipe")];
            //IsShieldAllowed = Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "shield")];
            
		}
		catch
		{
			ISfireswordallowed = false;
			isthunderswordallowed = false;
			
		}
	}

	// Update is called once per frame
	void Update()
	{
		
		if (global.GetComponent<Player_money>().Money >= 400 && ISfireswordallowed == false)
		{
			//ISfireswordallowed = true;
			button1.interactable = true;
		}
		else
		{
			button1.interactable = false;
		}
		if (global.GetComponent<Player_money>().Money >= 1000 && isthunderswordallowed == false)
		{
			//isthunderswordallowed = true;
			button2.interactable = true;
		}
		else
		{
			button2.interactable = false;
		}
        if (global.GetComponent<Player_money>().Money >= 600 && IsSuperSnipeAllowed == false)
        {
            button3.interactable = true;
        }
        else
        {
            button3.interactable = false;
        }
        if(global.GetComponent<Player_money>().Money >= 600 && IsShieldAllowed==false)
        {
            button4.interactable = true;
        }
        else
        {
            button4.interactable = false;
        }
	}
	public void changeTexte1()
    {
        button1text.text = "purchased";
        global.GetComponent<Player_money>().lossMOney(400);

        button1.GetComponent<Image>().color = Color.green;
		button1.interactable = false;
        ISfireswordallowed = true;
		Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "fire_sword")] = true;
	}
    
    public void changeTexte2()
    {
        button2text.text = "purchased";
        global.GetComponent<Player_money>().lossMOney(1000);
        button2.GetComponent<Image>().color = Color.green;
		button2.interactable = false;
		isthunderswordallowed = true;
		Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "thunder_sword")] = true;
	}
    public void changeTexte3()
    {
        button3text.text = "purchased";
        global.GetComponent<Player_money>().lossMOney(600);
        button3.GetComponent<Image>().color = Color.green;
        button3.interactable = false;
        IsSuperSnipeAllowed = true;
        //Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "super_snipe")] = true;

    }
    public void changeTexte4()
    {
        button4text.text = "purchased";
        global.GetComponent<Player_money>().lossMOney(600);
        button4.GetComponent<Image>().color = Color.green;
        button4.interactable = false;
        IsSuperSnipeAllowed = true;
        //Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "shield")] = true;

    }


}
