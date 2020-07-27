using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class UITest : MonoBehaviour
{
    [SerializeField] private HighScoreTable highScoreTable;
    // Start is called before the first frame update
    private void Start()
    {
        transform.Find("SubmitButton").GetComponent<Button_UI>().ClickFunc = () =>
        {
            ScoreInputWindow.Show_Static (0, (int score) => {

                ScoreInputWindow.Show_Static("", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", 3, (string nameText) =>
                {
                    highScoreTable.AddHighScoreEntry(score, nameText);
                });
            });
        };
    }

    
}
