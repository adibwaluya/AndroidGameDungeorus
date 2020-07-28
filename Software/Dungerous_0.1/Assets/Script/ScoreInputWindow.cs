using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreInputWindow : MonoBehaviour
{
    private static ScoreInputWindow instance;

    public Animator transitionAnime;
    private Button_UI okBtn;
    private Button_UI quitBtn;
    private TMP_InputField inputField;

    public void Awake()
    {
        instance = this; 
        
        okBtn = transform.Find("OkButton").GetComponent<Button_UI>();
        inputField = transform.Find("inputField").GetComponent<TMP_InputField>();

        Hide();
    }

    private void Update()
    {
        // TODO: Change this with CrossPlatformManager
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            okBtn.ClickFunc();
        }
    }
    // Show Window
    // TODO: Probably unnecessary to be implemented
    private void Show(string inputString, string validCharacters, int characterLimit, Action<string> onOk)
    {
        gameObject.SetActive(true);

        inputField.characterLimit = characterLimit;
        inputField.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(validCharacters, addedChar);
        };

        // Only for testing with random string
        inputField.text = inputString;

        okBtn.ClickFunc = () =>
        {
            //Hide();
            onOk(inputField.text);
            //QuitGame();
        }; 
    }

    private void ShowButton()
    {
        gameObject.SetActive(true);
    }

    // Hide Window
    // TODO: Probably unnecessary to be implemented
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private char ValidateChar(string validCharacters, char addedChar)
    {
        if(validCharacters.IndexOf(addedChar) != -1)
        {
            // Valid
            return addedChar;
        }
        else
        {
            // Invalid
            return '\0';
        }
    }

    public static void Show_Static(string inputString, string validCharacters, int characterLimit, Action<string> onOk)
    {
        instance.Show(inputString, validCharacters, characterLimit, onOk);
        //instance.QuitGame();
    }

    public static void Show_Static(int defaultInt, Action<int> onOk)
    {
        int score = 0;
        if(score != ScoreScript.scoreValue)
        {
            score = ScoreScript.scoreValue;
            //onOk(score);
            if(score == ScoreScript.scoreValue)
            {
                onOk(score);
                //instance.QuitGame();
            }
            //ScoreScript.scoreValue = 0;
        }
        else
        {
            onOk(defaultInt);
        }
        /*
        instance.Show(defaultInt.ToString(), "0123456789-", 20,
            (string inputText) =>
            {
                //inputText = ScoreScript.scoreValue.ToString();
                if (int.TryParse(inputText, out int _i))
                {
                    onOk(_i);
                }
                else
                {
                    onOk(defaultInt);
                }
            });
            */
        ScoreScript.scoreValue = 0;
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
