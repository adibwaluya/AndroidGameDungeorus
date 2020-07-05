using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetMainChar : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        characterList = new GameObject[transform.childCount];

        // Fill the Array with our characters
        for (int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        // Firstly, the characters are made invisible (toggle off the renderer)
        foreach(GameObject go in characterList)
        {
            go.SetActive(false);
        }

        // Toggle the selected character
        if (characterList[index])
            characterList[index].SetActive(true);
    }

    public void ToggleLeft()
    {

        index--;
        if (index < 0)
            index = characterList.Length - 1;

        // Toggle on the new model
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {

        index++;
        if (index == characterList.Length)
            index = 0;

        // Toggle on the new model
        characterList[index].SetActive(true);
    }

    public void PlayCharButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("PlayerOneScene");
    }

}
