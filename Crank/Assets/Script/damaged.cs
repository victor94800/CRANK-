using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damaged : MonoBehaviour {
    public int dmg;
    Animator anim;
    
    // Use this for initialization
    void Start ()
    {
		anim = GameObject.Find("Player").GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider hit)
    {
        
        if (hit.transform.tag == "enemy" )
        {
            
            hit.SendMessage("getHit", 10);
            
        }
    }
}


