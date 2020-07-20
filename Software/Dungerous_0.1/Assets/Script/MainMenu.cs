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
         WaitForSecondsRT wait = new WaitForSecondsRT(1);
         while (true)
         {
             transitionAnime.SetTrigger("end");
             yield return wait.NewTime(1.5f);
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         }
         //transitionAnime.SetTrigger("end");
         //yield return new WaitForSecondsRealtime(1.5f);
         //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }
}

public class WaitForSecondsRT : CustomYieldInstruction
{
    float m_Time;
    public override bool keepWaiting
    {
        get { return (m_Time -= Time.unscaledDeltaTime) > 0; }
    }
    public WaitForSecondsRT(float aWaitTime)
    {
        m_Time = aWaitTime;
    }
    public WaitForSecondsRT NewTime(float aTime)
    {
        m_Time = aTime;
        return this;
     }
}
