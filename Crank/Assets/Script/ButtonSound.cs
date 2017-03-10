using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ButtonSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip click;
    
    public void Onclick()
    {
        source.PlayOneShot(click);
    }

}
