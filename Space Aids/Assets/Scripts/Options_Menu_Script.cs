using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options_Menu_Script : MonoBehaviour
{
    //Holds the canvas that manages the options menu (AAJ)
    public Canvas optionsMenu;

    //Holds the playerTarget renderer (AAJ)
    public SpriteRenderer playerTarget;

    //Holds the player controller (AAJ)
    private PlayerController playerController;

    //Holds whether or not the game is paused (AAJ)
    public bool isPaused = false;

    // Use this for initialization
    void Start()
    {
        //The game starts unpaused (AAJ)
        isPaused = false;
        optionsMenu.enabled = false;

        //Finds the player controller
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }//Start

    //Update is called once per frame
    void Update()
    {
        //If the escape key pressed the title screen will be loaded (AAJ)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Toggles whether or not the game is paused (AAJ)
            if (isPaused == false)
            {
                //Sets the game to paused and displays the pause menu (AAJ)
                isPaused = true;
                optionsMenu.enabled = true;

                //Disables the player target (AAJ)
                playerTarget.enabled = false;

                //Adds the mouse back in (AAJ)
                Cursor.visible = true;

                //Pauses the game time (AAJ)
                Time.timeScale = 0;
            }//if
            else
            {
                //Unpauses the game and hides the pause menu (AAJ)
                isPaused = false;
                optionsMenu.enabled = false;

                //If the player exists in the scene (AAJ)
                if(playerController != null)
                {
                    //If the player is alive (AAJ)
                    if(playerController.isAlive == true)
                    {
                        //Enables the player target (AAJ)
                        playerTarget.enabled = true;

                        //Hides the mouse cursor (AAJ)
                        Cursor.visible = false;
                    }//if
                }//if

                //Unpauses the game time (AAJ)
                Time.timeScale = 1;
            }//else
        }//if
    }//Update

    /// <summary>
    /// Loads the title scene (AAJ)
    /// </summary>
    public void loadTitleScreen()
    {
        //Unpauses the game time (AAJ)
        Time.timeScale = 1;

        //Loads the title scene (AAJ)
        SceneManager.LoadScene("Title Scene");
    }//loadTitleScreen

    /// <summary>
    /// Exits the game (AAJ)
    /// </summary>
    public void exitGame()
    {
        //Exits the game (AAJ)
        Application.Quit();
    }//exitGame()
}
