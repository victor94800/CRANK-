using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	public int dmg = 10;
	public GameObject Explosion;

	void Start()
	{
	
	}

	// Update is called once per frame
	void Update() {

	}
	private void OnTriggerEnter(Collider hit)
	{
		// dit a l'enemy qu'il a ete fappé 
		if (hit.transform.tag == "PlayerController")
		{

			//player.GetComponent<PlayerController>().getHit(dmg);
			hit.SendMessage("getHit", dmg);
			Explosion.SetActive(true);

			

		}
		Explosion.SetActive(true);
		StartCoroutine(wait());
		
	}
	private IEnumerator wait()
	{
		yield return new WaitForSeconds(0.2f);
		Destroy(gameObject);
	}
}
