using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoosePlayer : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    private int PlayerNumber;
    public int SceneNumber;

    // Use this for initialization
    void Start()
    {
        PlayerNumber = 1;
        Player1.SetActive(true);
        Player2.SetActive(false);
        Player3.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 5"))
        {
            PlayerNumber = PlayerNumber + 1;
            if (PlayerNumber > 3)
            {
                PlayerNumber = 1;
            }
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            PlayerNumber = PlayerNumber - 1;
            if (PlayerNumber < 1)
            {
                PlayerNumber = 3;
            }
        }
        if (PlayerNumber == 1)
        {
            Player1.SetActive(true);
            Player2.SetActive(false);
            Player3.SetActive(false);
        }
        if (PlayerNumber == 2)
        {
            Player1.SetActive(false);
            Player2.SetActive(true);
            Player3.SetActive(false);
        }
        if (PlayerNumber == 3)
        {
            Player1.SetActive(false);
            Player2.SetActive(false);
            Player3.SetActive(true);
        }
        if (Input.GetKeyDown("joystick button 0"))
        {


            SceneManager.LoadScene(SceneNumber);
        }
    }
}
    

		
	

