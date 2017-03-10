using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnderWater : MonoBehaviour {
    private Transform tamera;
    GameObject h;
    
    
    //private GameObject under;
    // Use this for initialization
    void Start () {
       
        h =  GameObject.Find("water");
        //h = ;
        tamera = GameObject.Find("Camera").transform;
       
        h.SetActive(false);
       
        //h = UI.Find("Camera").image;
        //under = GameObject.Find("water").;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(tamera.transform.position.y <= 5f)
       {

           h.SetActive(true);
          
            
           
            

        }
        else
        {
           h.SetActive(false);

           
           


        }

		
	}
}
