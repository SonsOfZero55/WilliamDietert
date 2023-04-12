/*****************************************************************************
// File Name :         PressurePlateSystem.cs
// Author :            William Dietert
// Creation Date :     April 6, 2023
//
// Brief Description : This is the code for the pressure plate system and how Boxes 
will be able to come into contact with them and make things go away in certain
levels in the game.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateSystem : MonoBehaviour
{
    public GameObject calledObject;
    bool HasBoxOn = false;

    /// <summary>
    /// The lines below explains that when anything tagged with "Box" enters the 
    /// plate, it will destory the object you want if you put it into the Inspector.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Destroy(calledObject);
            HasBoxOn = true;
        }
    }

    /// <summary>
    /// These lines below changes the state of the pressure plate if a "Box" is 
    /// no longer on top of the plate itself.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            HasBoxOn = false;
        }
    }

    /// <summary>
    /// The lines below changes the pressure plate from red to green when anything
    /// with a "Box" tag has been places on it.
    /// </summary>
    public void FixedUpdate()
    {
        if (HasBoxOn == false)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
