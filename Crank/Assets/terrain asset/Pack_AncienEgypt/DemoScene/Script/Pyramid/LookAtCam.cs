using UnityEngine;
using System.Collections;

public class LookAtCam : MonoBehaviour {


	public GameObject cam;
	private Vector3 dirtomain;
	public bool zoom;
	
	// Use this for initialization
	void Start () {

		cam.SetActive(true);
		

	
	}
	
	
	// Update is called once per frame
	void Update () {
		dirtomain = cam.transform.position - transform.position;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 100);
		if (zoom)
		{
			if (Input.GetAxis("Vertical") > 0 && GetComponent<Camera>().fieldOfView > 5)
			{
				GetComponent<Camera>().fieldOfView -= Input.GetAxis("Vertical");
			}
			if (Input.GetAxis("Vertical") < 0 && GetComponent<Camera>().fieldOfView < 60)
			{
				GetComponent<Camera>().fieldOfView -= Input.GetAxis("Vertical");
			}
		}
		
	}
}
