using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosePhone : MonoBehaviour
{

    public GameObject Phone;
	public GameObject camera1;
	public GameObject camera2;
	public GameObject backgtound;
	public GameObject camera_button;
	public GameObject quete_buton;
	public GameObject enigmes_button;
	public GameObject player;
	public GameObject player4;
    public GameObject intello;
	// Update is called once per frame
	private void Start()
	{
		player = GameObject.Find("Player");
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
            Phone.SetActive(true);
			camera1.SetActive(false);
			camera2.SetActive(true);
			player.GetComponent<PlayerController>().enabled = true;
			player.SetActive(false);
			
		}
        else
        {
            Phone.SetActive(false);
			camera2.SetActive(false);
			camera1.SetActive(true);
			backgtound.SetActive(true);
			camera_button.SetActive(true);
			quete_buton.SetActive(true);
			enigmes_button.SetActive(true);
			player.GetComponent<PlayerController>().enabled = true;
			player.SetActive(true);
            intello.SetActive(false);
			
			
		}
    }

}

