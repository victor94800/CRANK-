using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

	// Use this for initialization
	private Animation anim;
	public GameObject parent;
	void Start ()
	{
		anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (anim.IsPlaying("Take 001"))
		{

		}
		else
		{
			
		}
		
	}
}
