using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class transition : MonoBehaviour {
    public GameObject toactivate;
    public Text flashingText;
    // Use this for initialization
    void Start ()
    {
        flashingText.enabled = true;
        toactivate.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 7"))
        {
            toactivate.SetActive(true);
            flashingText.enabled = false;
        }
	}
}
