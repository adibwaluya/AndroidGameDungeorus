using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    public Animator transitionAnime;

    void Update()
    {

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


        void resume()
        {
            pauseMenuUi.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        void pause()
        {
            pauseMenuUi.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        // TODO: Fix this function
        void QuitGame()
        {
            StartCoroutine(LoadScene());
        }

        IEnumerator LoadScene()
        {
            transitionAnime.SetTrigger("end");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
