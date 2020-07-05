using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator transitionAnime;

    public void StartGame()
     {
         StartCoroutine(LoadScene());
        
     }

     IEnumerator LoadScene()
     {
         transitionAnime.SetTrigger("end");
         yield return new WaitForSeconds(1.5f);
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }
}
