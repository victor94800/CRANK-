using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosePause : MonoBehaviour
{

    public GameObject pauseM;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (pauseM.activeInHierarchy == false)
        {
            pauseM.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseM.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

