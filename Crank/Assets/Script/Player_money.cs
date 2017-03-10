using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_money : MonoBehaviour {
    public int Money;
    public Text moneytext;
   
    // Use this for initialization
    void Start () {
        Money = 0;
        
        moneytext.text = "money :" + Money.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddMoney(int a)
    {
        Money += a;
        moneytext.text = "money :" + Money.ToString();
       
    }
}
