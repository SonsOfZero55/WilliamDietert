
/*****************************************************************************
// File Name :         GameOverScript.cs
// Author :            William Dietert
// Creation Date :     April 10, 2023
//
// Brief Description : This is the code for allowing the player to restart the game 
when it has been beaten.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    float currentTime;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
