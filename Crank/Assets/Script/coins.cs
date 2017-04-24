using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour {
    
    float speed;
    
    public GameObject global;
	private float time;
	private float endTime;
    // Use this for initialization
    void Start ()
    {
		time = Time.fixedTime;
		speed = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
		print(time);
		print(Time.deltaTime);
		print(speed);

       transform.Rotate(speed * 5, 0, 0);
	   if (endTime + 5 <= Time.fixedTime)
		{
			Destroy(this.gameObject);
		}
	   if (time + 1 <= Time.fixedTime )
		{
			speed += 1;
			time = Time.fixedTime;
			
		}
			
           
    }
   
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "Player")
		{
			global.GetComponent<Player_money>().AddMoney(1);
			Destroy(this.gameObject);
		}
	}
}
