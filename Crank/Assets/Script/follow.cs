using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
    private Transform Target;
    Vector3 dirtomain;
    // Use this for initialization
    void Start () {
        Target = GameObject.Find("Target").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //dirtomain = GameObject.Find("Target").transform.position - transform.position;
        transform.position = Vector3.Lerp(transform.position , Target.position, 10f);
        transform.LookAt(GameObject.Find("Target").transform);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 10f);

    }
}
