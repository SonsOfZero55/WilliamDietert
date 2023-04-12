/*****************************************************************************
// File Name :         NextLevelTeleport.cs
// Author :            William Dietert
// Creation Date :     April 7, 2023
//
// Brief Description : This is the code for the teleport system and how the player 
will move from one level to the next without issue.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTeleport : MonoBehaviour
{
    public int sceneBuildIndex;

    /// <summary>
    /// Once the player enters the transport area, it will access the SceneManager
    /// and teleport them to the next level.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            // Player entered, so move on to next level
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
