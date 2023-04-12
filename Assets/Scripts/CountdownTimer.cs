/*****************************************************************************
// File Name :         CountdownTimer.cs
// Author :            William Dietert
// Creation Date :     April 8, 2023
//
// Brief Description : This is the code for the timer system. It includes
how it ticks down and what will happen if the timer reaches zero.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 45f;
    [SerializeField] Text countdownText;

    /// <summary>
    /// The line below has the timer starting at the time set in the startingTime 
    /// float above.
    /// </summary>
    void Start()
    {
        currentTime = startingTime;
    }

    /// <summary>
    /// The lines below lowers the timer by 1 number per second, until the timer 
    /// reaches zero, then the timer will stop and access the SceneManager to 
    /// restart the level.
    /// </summary>
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
        }

        if(currentTime == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
