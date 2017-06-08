using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playanimation : MonoBehaviour {
	Animation anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			print("ggg");
			anim.CrossFade("Run",2f);
		}
	}
}
