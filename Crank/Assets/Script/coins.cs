using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour {
    
    float speed;
    
    public GameObject cam;
    
    // Use this for initialization
    void Start ()
    {
        
        
        speed = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
      
            transform.Rotate(speed * 5, 0, 0);
       

       

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player")
        {
            cam.GetComponent<Player_money>().AddMoney(1);
            Destroy(this.gameObject);
        }
    }
}
