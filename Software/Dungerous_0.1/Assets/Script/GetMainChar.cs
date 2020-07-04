using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainChar : MonoBehaviour
{
    public GameObject playerOne, playerTwo;
    private GameObject myChar;

    private readonly string selectedCharacter = "SelectedCharacter";

    void Start()
    {
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        switch (getCharacter)
        {
            case 1:
                myChar = playerOne;
                break;
            case 2:
                myChar = playerTwo;
                break;
            default:
                myChar = playerOne;
                break;
        }
    }

}
