using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobShop : MonoBehaviour {
    public int money;
    public bool ISfireswordallowed;
    public bool isthunderswordallowed;
    public bool isdoublejumpallowed;
    public Button button1;
    public Button button2;
    public Button button3;
    // Use this for initialization
    void Start()
    {
        //money = 100;
        ISfireswordallowed = false;
        isthunderswordallowed = false;
        isdoublejumpallowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (money >= 300)
        {
            isdoublejumpallowed = true;
            button1.interactable = true;

        }
        if (money>=1000)
        {
            ISfireswordallowed = true;
            button2.interactable = true;
        }
        if (money>=2000)
        {
            isthunderswordallowed = true;
            button3.interactable = true;
        }
	}
}
