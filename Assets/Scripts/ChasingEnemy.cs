/*****************************************************************************
// File Name :         ChasingEnemy.cs
// Author :            William Dietert
// Creation Date :     April 6, 2023
//
// Brief Description : This is the code for the enemies that will chase you around 
some of the stages and how they will track you.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingEnemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public int speed = 1;
    public int Respawn;

    /// <summary>
    /// The lines below how the enemy follows the player around the level.
    /// </summary>
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
        Player.transform.position, speed * Time.deltaTime);
    }

    /// <summary>
    /// The lines below explains that when the enemy triggers with anything that is
    /// tagged "Player", it will access the SceneManager and respawn them at the 
    /// beginning of the room.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(Respawn);
        }
    }
}
