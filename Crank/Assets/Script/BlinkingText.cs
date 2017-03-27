using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    //public GameObject toactivate;
    //public GameObject todisable;
    Text flashingText;

    void Start()
    {
        
        flashingText = GetComponent<Text>();
        
        StartCoroutine(BlinkText());
    }


    public IEnumerator BlinkText()
    {

        while (!(Input.GetKeyDown(KeyCode.Space) || Input.GetKey("joystick button 7")))
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey("joystick button 7"))
            {

                flashingText.enabled = false;
                //toactivate.SetActive(true);
            }
            flashingText.text = "";

            yield return new WaitForSeconds(.7f);

            flashingText.text = "Press start/enter!";
            yield return new WaitForSeconds(.5f);
            
        }
    
        
    }

}
