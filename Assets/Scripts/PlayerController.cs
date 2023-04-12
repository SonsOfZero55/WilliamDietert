/*****************************************************************************
// File Name :         PlayerController.cs
// Author :            William Dietert
// Creation Date :     April 1, 2023
//
// Brief Description : This is the code for how the player character is controlled
and what actions the player character is able to do on their own.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerControls controls;
    Vector2 movement;
    private ButtonScript BScript;
    public GameObject grabbedBox;
    bool heldBox = false;

    /// <summary>
    /// The lines below performs or cancels any of the players movements depending 
    /// on what the player is doing in that moment.
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();

        controls.PlayerActions.Open.performed += ctx => Open();

        controls.PlayerActions.Move.performed += ctx => movement = 
        ctx.ReadValue<Vector2>();

        controls.PlayerActions.Move.canceled += ctx => movement = Vector2.zero;

        controls.PlayerActions.Grab.performed += ctx => Grab();
    }

    /// <summary>
    /// The lines below apply to the character movement and sets the character move 
    /// speed to five.
    /// </summary>
    private void FixedUpdate()
    {
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 5f * 
        Time.deltaTime;
        transform.Translate(movementVelocity, Space.World);

        if (heldBox == true)
        {
            grabbedBox.transform.position = transform.position;
        }
    }


    /// <summary>
    /// The code is trying to open the script, but if it is null, then nothing will 
    /// happen Otherwise, the wall function on BScript will open a door.
    /// </summary>
    private void Open()
    {
        if (BScript == null)
        {
            return;
        }

        BScript.Wall();
    }

    /// <summary>
    /// The line below enables the player controls in the private void Awake.
    /// </summary>
    private void OnEnable()
    {
        controls.PlayerActions.Enable();
    }

    /// <summary>
    /// The line below disables the player controls when they are not moving in the 
    /// scene.
    /// </summary>
    private void OnDisable()
    {
        controls.PlayerActions.Disable();
    }

    /// <summary>
    /// These lines below allows the player to use the A button to open the doors in
    /// the levels.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Button"))
        {
            BScript = collision.gameObject.GetComponent<ButtonScript>();
        }
    }

    /// <summary>
    /// These lines below state that when the player is not in the area of a button, 
    /// they cannot actiavte any buttons at all.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Button"))
        {
            BScript = null;
        }
    }

    /// <summary>
    /// These lines state that if you are not walking into a box, the grabbedbox 
    /// fuction will be null and will not be active until you walk into one.
    /// </summary>
    private void Grab()
    {
        if (grabbedBox == null)
        {
            return;
        }
        else
        {
            heldBox = !heldBox;
            grabbedBox.GetComponent<BoxCollider2D>().isTrigger = false;
            grabbedBox = null;
            print(heldBox);
        }
    }

    /// <summary>
    /// These lines state that once you walk into a box, the box can be grabbed and
    /// moved with the player.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            grabbedBox = collision.gameObject;
            heldBox = true;
            grabbedBox.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    /// <summary>
    /// These lines state that if the player is not in the area of a box, it cannot 
    /// be grabbed by the player.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            grabbedBox = null;
        }
    }

    /// <summary>
    /// This trigger actives once the player presses a button, then it will destory 
    /// any wall the player states in the inspector
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Contains("DestroyBox"))
        {
            BScript.Wall();
        }
    }
}
