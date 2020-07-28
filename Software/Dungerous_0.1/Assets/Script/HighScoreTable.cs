using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        
        // PlayingPrefs: simplest way of saving and loading persistent data
        // SetString allows to store a string which contains all of the highscores
        // To store the string, JSON data format will be
        string jsonString = PlayerPrefs.GetString("HighScoreBoard");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);
        
        if (highscores == null)
        {
            /*
            AddHighScoreEntry(100000, "Mike");
            AddHighScoreEntry(12343, "Waluthon");
            AddHighScoreEntry(46654, "John");
            AddHighScoreEntry(89876, "Max");
            AddHighScoreEntry(65433, "Carl");
            AddHighScoreEntry(78996, "May");
            AddHighScoreEntry(23567, "Joe");
            AddHighScoreEntry(98422, "Nathan");
            */
            //clearScoreTable();
            // Reload
            jsonString = PlayerPrefs.GetString("HighScoreBoard");
            highscores = JsonUtility.FromJson<HighScores>(jsonString);
            //clearScoreTable();
        }

        // Sort entry list by Score

        for (int i = 0; i < highscores.highScoreEntryList.Count; i++)
        {
            for(int j = i + 1; j < highscores.highScoreEntryList.Count; j++)
            {
                if(highscores.highScoreEntryList[j].score > highscores.highScoreEntryList[i].score)
                {
                    // Swap
                    HighScoreEntry tmp = highscores.highScoreEntryList[i];
                    highscores.highScoreEntryList[i] = highscores.highScoreEntryList[j];
                    highscores.highScoreEntryList[j] = tmp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach(HighScoreEntry highScoreEntry in highscores.highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }

        
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {

        float templateHigh = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHigh * transformList.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = transformList.Count + 1;
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

        int score = highScoreEntry.score;
        entryTransform.Find("ScoreHeader").GetComponent<Text>().text = score.ToString();

        string name = highScoreEntry.name;
        entryTransform.Find("NameHeader").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    public void AddHighScoreEntry(int score, string name)
    {
        // Create HighscoreEntry
        HighScoreEntry highscoreEntry = new HighScoreEntry { score = score, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("HighScoreBoard");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

        if(highscores == null)
        {
            highscores = new HighScores()
            {
                highScoreEntryList = new List<HighScoreEntry>()
            };
        }
        // Add new entry to Highscores
        highscores.highScoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("HighScoreBoard", json);
        PlayerPrefs.Save();
    }

    private void clearScoreTable()
    {
        // Load saved scores
        string jsonString = PlayerPrefs.GetString("HighScoreBoard");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

        // Clear score table
        highscores.highScoreEntryList.Clear();

        // Save updated scores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("HighScoreBoard", json);
        PlayerPrefs.Save();
        
    }

    /*
     * Contains HighScoreEntryList
     */
    private class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }

    /*
     * Represents a single High Score Entry
    */
    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
