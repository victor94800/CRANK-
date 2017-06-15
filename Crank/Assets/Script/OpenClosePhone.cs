using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosePhone : MonoBehaviour
{

    public GameObject Phone;
    public GameObject intello;
    public GameObject PhoneCamera;
    public GameObject FpCamera;
    public GameObject NormalCamera;
	public GameObject apps;
	public GameObject player;
	// Update is called once per frame
	private void Start()
	{
		
	}
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
            NormalCamera.SetActive(false);
            FpCamera.SetActive(true);
            PhoneCamera.SetActive(true);
            Phone.SetActive(true);
			player.GetComponent<PlayerController>().stop = true;
			
			
		}
        else
        {
			for (int i = 0; i < apps.transform.childCount; i++)
			{
				apps.transform.GetChild(i).gameObject.SetActive(true);
			}
			NormalCamera.SetActive(true);
            FpCamera.SetActive(false);
            PhoneCamera.SetActive(false);
            Phone.SetActive(false);
		    player.GetComponent<PlayerController>().stop = false;
			intello.SetActive(false);
			
			
		}
    }
	public void PhoneMission()
	{
		if (Phone.activeInHierarchy == false)
		{
			apps.SetActive(false);
			NormalCamera.SetActive(false);
			FpCamera.SetActive(true);
			PhoneCamera.SetActive(true);
			Phone.SetActive(true);
			player.GetComponent<PlayerController>().stop = true;
			

		}
		else
		{
			for (int i = 0; i < apps.transform.childCount; i++)
			{
				apps.transform.GetChild(i).gameObject.SetActive(true);
			}
			apps.SetActive(true);
			NormalCamera.SetActive(true);
			FpCamera.SetActive(false);
			PhoneCamera.SetActive(false);
			Phone.SetActive(false);
			player.GetComponent<PlayerController>().stop = false;
			intello.SetActive(false);


		}
	}

}

