using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosePhone : MonoBehaviour
{

    public GameObject Phone;


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
            
        }
        else
        {
            Phone.SetActive(false);
            
        }
    }

}

