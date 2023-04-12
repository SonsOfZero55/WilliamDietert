/*****************************************************************************
// File Name :         ButtonScript.cs
// Author :            William Dietert
// Creation Date :     April 3, 2023
//
// Brief Description : This is the code for buttons and how they destroy certain 
barrairs when told to.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int health = 100;
    public int mana = 50;
    [SerializeField] private GameObject gameDie;
    public GameObject DestroyWall;

    /// <summary>
    /// The line below is a setter and getter that will set destroyWall equal to 
    /// null because there are no more walls left in the game.
    /// </summary>
    public GameObject GameDie { get => gameDie; set => gameDie = value; }

   /// <summary>
   /// The health system attaches to the wall so that when it goes down it will
   /// deplete the health and get rid of the wall.
   /// </summary>
    void Start()
    {
        health -= 20;
    }

    /// <summary>
    /// The line below destorys anything with DestroyWall attached to it.
    /// </summary>
    public void Wall()
    {
        Destroy(DestroyWall);
    }
}
