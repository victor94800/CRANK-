using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damaged : MonoBehaviour {
    public int dmg;
  
    // Use this for initialization
    void Start ()
    {
		
       
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider hit)
    {
        // dit a l'enemy qu'il a ete fappé 
        if (hit.transform.tag == "enemy" )
        {
            
            hit.SendMessage("getHit", dmg);
            
        }
    }
}


