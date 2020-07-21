using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    public Animator transitionAnime;
    public GameObject button;

    // TODO: Fix this function
    public void QuitGame()
    {
        if(Time.timeScale == 0f)
        {
            StartCoroutine(LoadScene());
            Time.timeScale = 1f;
        }
        
               
    }

    IEnumerator LoadScene()
    {
        WaitForSecondsRT anotherWait = new WaitForSecondsRT(1);
        while (true)
        {
            transitionAnime.SetTrigger("end");
            yield return anotherWait.NewTime(0.1f);
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    //void Update()
    //{
        
        
              
        /*
        void pauseGame()
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
        */
        
    //}

    public void resume()
    {
        //pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void pause()
    {
        //pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Continouity()
    {
        if (GameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}


