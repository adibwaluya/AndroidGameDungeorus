using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class UITest : MonoBehaviour
{
    [SerializeField] private ScoreInputWindow inputWindow;
    // Start is called before the first frame update
    private void Start()
    {
        transform.Find("SubmitButton").GetComponent<Button_UI>().ClickFunc = () =>
        {
            inputWindow.Show("Qwerty", (string inputText) => {
                CMDebug.TextPopupMouse("Ok: " + inputText);
            });
        };
    }

    
}
