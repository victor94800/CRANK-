using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosePhone : MonoBehaviour
{

    public GameObject Phone;
	public GameObject camera1;
	public GameObject camera2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 6"))
        {
            phone();
        }
    }
    public void phone()
    {
        if (Phone.activeInHierarchy == false)
        {
            Phone.SetActive(true);
			camera1.SetActive(false);
			camera2.SetActive(true);
            
        }
        else
        {
            Phone.SetActive(false);
			camera2.SetActive(false);
			camera1.SetActive(true);
		}
    }

}

