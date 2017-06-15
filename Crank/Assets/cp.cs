using UnityEngine;
using UnityEngine.Networking;

public class cp : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public GameObject S_chekpoint;

    private void OnTriggerEnter(Collider other)
    {
       
         Destroy(gameObject);
         S_chekpoint.SetActive(true);
    }
}
