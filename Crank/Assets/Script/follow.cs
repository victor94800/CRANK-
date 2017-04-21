using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
    private Transform Target;
    Vector3 dirtomain;
    // Use this for initialization
    void Start () {
        Target = GameObject.Find("player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
		//dirtomain = GameObject.Find("Target").transform.position - transform.position;
		if (Target.transform.position != transform.position)
		{
			transform.position = Target.transform.position;
			transform.rotation = Target.transform.rotation ;
		}
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 10f);

    }
}
