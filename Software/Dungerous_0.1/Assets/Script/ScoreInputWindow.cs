using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using TMPro;

public class ScoreInputWindow : MonoBehaviour
{
    private static ScoreInputWindow instance;

    private Button_UI okBtn;
    private TMP_InputField inputField;

    public void Awake()
    {
        instance = this; 
        Hide();
        okBtn = transform.Find("OkButton").GetComponent<Button_UI>();
        inputField = transform.Find("inputField").GetComponent<TMP_InputField>();
        
        
    }

    private void Update()
    {
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
            Hide();
            onOk(inputField.text);
        }; 
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
    }

    public static void Show_Static(int defaultInt, Action<int> onOk)
    {
        instance.Show(defaultInt.ToString(), "0123456789-", 20,
            (string inputText) =>
            {
                if (int.TryParse(inputText, out int _i))
                {
                    onOk(_i);
                }
                else
                {
                    onOk(defaultInt);
                }
            });
    }
}
