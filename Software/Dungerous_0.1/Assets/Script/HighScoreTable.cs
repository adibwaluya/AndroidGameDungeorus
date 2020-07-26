using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHigh = 30f;
        for (int i = 0; i < 8 ; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHigh * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + "TH";
                    break;

                case 1:
                    rankString = "1ST";
                    break;
                case 2:
                    rankString = "2ND";
                    break;
                case 3:
                    rankString = "3RD";
                    break;

            }
            entryTransform.Find("PosHeader").GetComponent<Text>().text = rankString;

            int score = Random.Range(0, 10000);
            entryTransform.Find("ScoreHeader").GetComponent<Text>().text = score.ToString();

            string name = "John";
            entryTransform.Find("NameHeader").GetComponent<Text>().text = name;
        }
        
    }
}
