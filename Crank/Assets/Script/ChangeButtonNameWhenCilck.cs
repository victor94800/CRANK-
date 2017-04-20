using System.Collections;
using System.Collections.Generic;
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
    public void changeTexte1()
    {
        button1text.text = "purchased";
        GetComponent<Image>().color = Color.black;
        
    }
    public void changeTexte2()
    {
        button2text.text = "purchased";
        GetComponent<Image>().color = Color.black;
    }
    public void changeTexte3()
    {
        button3text.text = "purchased";
        GetComponent<Image>().color = Color.black;

    }
	
}
