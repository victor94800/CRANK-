using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour {
    private Transform TargetCamera;
    //private Transform camerapos = GameObject.Find("cameratarget").transform;
	// Use this for initialization
	void Start ()
    {
        
        TargetCamera = GameObject.Find("Player").transform;
	}

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, TargetCamera.position, 10f);
        if (Input.GetAxis("Vertical") != 0 && ( transform.rotation.x != 0 && transform.rotation.y != 0 && transform.rotation.z != 0))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(10,0,0)), 10f);

        }
    }

       
		
	}

