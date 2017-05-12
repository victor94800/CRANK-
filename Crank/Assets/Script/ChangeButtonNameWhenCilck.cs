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
    public Button button1;
    public Button button2;
    public Button button3;
	
	public int money;
    public bool ISfireswordallowed;
	public bool isthunderswordallowed;
	public bool isdoublejumpallowed;

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
			isdoublejumpallowed = Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "double_jump")];
			money = Game_Controller_script.money;
		}
		catch
		{
			ISfireswordallowed = false;
			isthunderswordallowed = false;
			isdoublejumpallowed = false;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (money >= 300 && isdoublejumpallowed == false)
		{
			//isdoublejumpallowed = true;
			button1.interactable = true;

		}
		else
		{
			button1.interactable = false;
		}
		if (money >= 1000 && ISfireswordallowed == false)
		{
			//ISfireswordallowed = true;
			button2.interactable = true;
		}
		else
		{
			button2.interactable = false;
		}
		if (money >= 2000 && isthunderswordallowed == false)
		{
			//isthunderswordallowed = true;
			button3.interactable = true;
		}
		else
		{
			button3.interactable = false;
		}
	}
	public void changeTexte1()
    {
        button1text.text = "purchased";
		money -= 300;
		button1.GetComponent<Image>().color = Color.green;
		button1.interactable = false;
		isdoublejumpallowed = true;
		Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "double_jump")] = true;
	}
    public void changeTexte2()
    {
        button2text.text = "purchased";
		money -= 1000;
		button2.GetComponent<Image>().color = Color.green;
		button2.interactable = false;
		ISfireswordallowed = true;
		
		Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "fire_sword")] = true; 
	}
    public void changeTexte3()
    {
        button3text.text = "purchased";
		money -= 2000;
		button3.GetComponent<Image>().color = Color.green;
		button3.interactable = false;
		isthunderswordallowed = true;
		Game_Controller_script.item_allowed[Array.IndexOf(Gamecontroller.GetComponent<GameController>().item_name, "thunder_sword")] = true;
	}
	
}
