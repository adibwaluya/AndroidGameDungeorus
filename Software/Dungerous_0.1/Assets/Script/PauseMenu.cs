using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    public Animator transitionAnime;

    // TODO: Fix this function
    public void QuitGame()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnime.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        if (GameIsPaused)
        {
            resume();
        }
        else
        {
            pause();
        }

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
        
    }

    public void resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
