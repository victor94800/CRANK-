using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 [RequireComponent(typeof(AudioSource))]
public class Videoplayer : MonoBehaviour {

    public MovieTexture movie;
    private AudioSource audio;
    
    
	void Start ()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
        
	}
	
	
	void Update ()
    {
        if (!movie.isPlaying)
        {
            Debug.Log("movie end");
            SceneManager.LoadScene(1);

        }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey("joystick button 7"))
        {
            SceneManager.LoadScene(1);
        }
    }
    
  
  
}
