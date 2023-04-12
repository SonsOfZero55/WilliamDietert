/*****************************************************************************
// File Name :         MainMenuScript.cs
// Author :            William Dietert
// Creation Date :     April 10, 2023
//
// Brief Description : This is the code for the main menu so you can start plaing 
the game or if you want to quit the game.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
