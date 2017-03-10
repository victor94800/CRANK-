using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float rotationspeed = 5f;
    
   // public GameObject player;
   // private Vector3 offset ;
    // Use this for initialization
    void Start ()
    {
        //offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Horizontal2") == 1 || Input.GetAxis("Horizontal2") == -1)
        {
            // transform.position = player.transform.position + offset; 
            // transform.Translate((Input.GetAxis("") * rotationspeed), 0, Input.GetAxis("Horizontal2") * rotationspeed);
            transform.Rotate(0, Input.GetAxis("Horizontal2") * rotationspeed, 0);
        }
       /* else if (Input.GetAxis("Vertical2") == 1 )
        {
            transform.Rotate(0, 0, Input.GetAxis("Vertical2") * rotationspeed);
        }*/
        //transform.Rotate(0, 0, 0);
        //transform.RotateAround(Target.position, new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")), 300 * Time.deltaTime);
    }
}
