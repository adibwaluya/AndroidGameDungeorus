using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;
using UnityEngine.SceneManagement;

public class UITest : MonoBehaviour
{
    public Animator transitionAnime;

    [SerializeField] private HighScoreTable highScoreTable;
    // Start is called before the first frame update
    private void Start()
    {
        transform.Find("SubmitButton").GetComponent<Button_UI>().ClickFunc = () =>
        {
            //int score = ScoreScript.scoreValue;
            ScoreInputWindow.Show_Static (0, (int score) => {

                ScoreInputWindow.Show_Static("", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", 3, (string nameText) =>
                {
                    highScoreTable.AddHighScoreEntry(score, nameText);
                });
            });
        };
    }

    public void QuitGame()
    {
        StartCoroutine(LoadScene());

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


}
