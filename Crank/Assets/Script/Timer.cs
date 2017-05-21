using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	private float time;
	private GameObject GO;
	// Use this for initialization
	public void Reactivate(GameObject Go , float time)
	{
		this.GO = Go;
		this.time = time;
	}
	
	// Update is called once per frame
	IEnumerator TimetoRestart()
	{
		while (time > 0)
		{
			yield return new WaitForSeconds(1);
			time--;
		}
		if (GO != null)
		{
			GO.SetActive(true);
		}
		Destroy(this);
	}
}
