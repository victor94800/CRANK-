using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour {
    
    float speed;
    
    public GameObject global;
	private float time = 0;
	private float endTime = 10;
	public float time2;
    // Use this for initialization
    void Start ()
    {
		time = 0;
		time2 = 0;
		speed = 1;
		global = GameObject.Find("Global");
    }
	
	// Update is called once per frame
	void Update ()
    {
	   transform.position = new Vector3(transform.position.x, 7, transform.position.z);
	   time += Time.deltaTime;
       transform.Rotate(speed * 5, 0, 0);
	   if (time >= endTime)
		{
			Destroy(this.gameObject);
		}
	   if (time  >= time2 + 1  )
		{
			speed += 1;
			time2 = time;
			
		}
			
           
    }

	/*private void 
	{
		if (other.transform.name == "Player")
		{
			global.GetComponent<Player_money>().AddMoney(1);
			Destroy(this.gameObject);
		}
	}*/
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.name == "player")
		{
			global.GetComponent<Player_money>().AddMoney(1);
			Destroy(this.gameObject);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "player")
		{
			global.GetComponent<Player_money>().AddMoney(1);
			Destroy(this.gameObject);
		}
	}

}
