using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadSceneOnClick : MonoBehaviour {

    AudioSource AudioM;
    AudioSource AudioSfx;
    
    private void Start()
    {
        AudioM = GameObject.Find("Quad").GetComponent<AudioSource>();
       // PlayerPrefs.
       AudioM.volume= PlayerPrefs.GetFloat("MusicV");
       
    }

    private void OnDestroy()
    {
        
        PlayerPrefs.SetFloat("MusicV", (AudioM.volume));
        PlayerPrefs.Save();
        //PlayerPrefs.SetFloat("SfxV", (AudioSfx.volume));
    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    

}

