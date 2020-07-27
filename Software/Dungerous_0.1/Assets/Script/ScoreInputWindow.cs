using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using TMPro;

public class ScoreInputWindow : MonoBehaviour
{
    private TMP_InputField inputField;
    private Button_UI okBtn;
    

    public void Awake()
    {
        Hide();
        okBtn = transform.Find("OkButton").GetComponent<Button_UI>();
        inputField = transform.Find("inputField").GetComponent<TMP_InputField>();
        
        
    }
    // Show Window
    // TODO: Probably unnecessary to be implemented
    public void Show(string inputString, Action<string> onOk)
    {
        gameObject.SetActive(true);

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
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
