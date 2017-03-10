using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBarScript : MonoBehaviour {
    private  AsyncOperation ao;
    public GameObject loadingScreenBG;
    public Image progress;
    public Image progBar;
    public Text loadingText;
    public bool isFakeLoadingBar = false;
    public float fakeIncrement = 0f;
    public float fakeTiming = 0f;
    public Text loadingText2;
    public int levelnumber;


    // Use this for initialization
    void Start ()
    {
      

    }

    // Update is called once per frame
    void Update()
    {



    }
    public void LoadLevel01()
    {
        loadingScreenBG.SetActive(true);
        progBar.gameObject.SetActive(true);
        progress.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(true);
        loadingText2.gameObject.SetActive(false);
        //loadingText.text = "Now Loading...";
        if (!isFakeLoadingBar)
        {
            StartCoroutine(LoadLevelWithRealProgress());
        }
        else
        {

        }


    }
    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1);
        ao = SceneManager.LoadSceneAsync(levelnumber);
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            loadingText.text = "Now Loading... " + (int)((ao.progress + 0.1) * 100) + "%";
            progBar.fillAmount = ao.progress+0.1f;
            if (ao.progress == 0.9f)
            {
                loadingText2.gameObject.SetActive(true);
                loadingText.text = "Level Loaded";
                loadingText2.text = "Press 'Space bar' or 'Start' to continue...";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey("joystick button 7"))
                {
                    ao.allowSceneActivation = true;
                }

            }
           
            yield return null;
        }


    }
   
}
