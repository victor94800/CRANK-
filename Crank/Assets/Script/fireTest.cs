using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireTest : MonoBehaviour {
	public GameObject bullet;
	public int Speed;
	public int distance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Fire.fire(bullet, transform.position,transform, Speed, distance);
		}
		
	}
	public IEnumerator fire()
	{
		yield return new WaitForSeconds(5);

	}
}
