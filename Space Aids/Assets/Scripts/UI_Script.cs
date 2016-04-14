using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour {

    //Holds the player (AAJ)
    private GameObject player;

    //Holds the player's portrait (AAJ)
    private GameObject playerPortrait;

    //Holds the bank the UI uses to update the screen with the correct amount of money (AAJ)
    private Bank_Script bank;

    //Holds the text that displays the amount of money the player has (AAJ)
    public Text moneyText;

    //Holds the player's backgrounds (AAJ)
    private SpriteRenderer pinkBackground;
    private SpriteRenderer blueBackground;

    //Holds the toggle for flash protection (AAJ)
    public Toggle flashProtectionToggle;

    //Holds whether no the sprite will change (AAJ)
    public bool flashProtection = true;

    //Holds how high count needs to go before the background will change (AAJ)
    public int maxBackgroundTimer = 20;

    //Holds the counter for alternating the backgrounds (AAJ)
    private int backgroundTimer = 0;

    //Holds the images on the tool bar (AAJ)
    public GameObject rotationArrowIcon;
    public GameObject trashCanIcon;
    public GameObject basicTurretIcon;

    //Holds the timers on the tool bar (AAJ)
    public GameObject timer1;
    public GameObject timer2;
    public GameObject timer3;
    
    // Use this for initialization
    void Start ()
    {
        //Gets the player (AAJ)
        player = GameObject.FindGameObjectWithTag("Player");
        
        //Gets the player portrait and its backgrounds (AAJ)
        playerPortrait = GameObject.FindGameObjectWithTag("Player Portrait");

        //Finds the bank (AAJ)
        bank = GameObject.FindGameObjectWithTag("Bank").GetComponent<Bank_Script>();

        //Gets the backgrounds if the player portrait exists (AAJ)
        if (playerPortrait != null)
        {
            pinkBackground = playerPortrait.transform.GetChild(0).GetComponent<SpriteRenderer>();
            blueBackground = playerPortrait.transform.GetChild(1).GetComponent<SpriteRenderer>();
        }//if
    }//start

    // Fixed Update is called consistently 
    void FixedUpdate ()
    {
        //Alters the Player Portrait backgrounds if the player portrait exists (AAJ)
        if(playerPortrait != null)
        {
            //Only changes sprites if their is no flash protection (AAJ)
            if (flashProtection == false)
            {
                //Manages the player's sprites (AAJ)
                BackgroundManager();
            }//if
        }//if

        //Updates the display with correct amount of money
        moneyText.text = "$" + bank.playerFunds + "K";

        //Updates the tool bar based on the cool downs (AAJ)
        ManageToolBar();

    }//fixed update

    /// <summary>
    /// Alternates between the player's two backgrounds for a flashing effect (AAJ)
    /// </summary>
    void BackgroundManager()
    {
        if ((pinkBackground.enabled == true) && (backgroundTimer == maxBackgroundTimer))
        {
            pinkBackground.enabled = false;
            blueBackground.enabled = true;

            //Resets count (AAJ)
            backgroundTimer = 0;
        }//if
        else if ((blueBackground.enabled == true) && (backgroundTimer == maxBackgroundTimer))
        {
            pinkBackground.enabled = true;
            blueBackground.enabled = false;

            //Resets count (AAJ)
            backgroundTimer = 0;
        }//else if

        //Updates sprite count (AAJ)
        backgroundTimer++;
    }//SpriteManager()

    /// <summary>
    /// Toggles the flash protection for the player portrait and space ship (AAJ)
    /// </summary>
    public void ToggleFlashProtection()
    {
        if(flashProtection == true)
        {
            flashProtection = false;

            //Toggles the player's flash protection (AAJ)
            if (player != null)
            {
                player.GetComponent<PlayerController>().flashProtection = false;
            }//if
        }//if
        else
        {
            flashProtection = true;

            //Toggles the player's flash protection (AAJ)
            if (player != null)
            {
                player.GetComponent<PlayerController>().flashProtection = true;
            }//if
        }//else
    }//ToggleFlashProtection()

    /// <summary>
    /// Manages the tool bar based on the cool downs (AAJ)
    /// </summary>
    void ManageToolBar()
    {
        //Toggles between the icon's image and the timer image based on the corresponding cool down (AAJ)
        if(player.GetComponent<PlayerController>().rotateCoolDownOn == true)
        {
            rotationArrowIcon.GetComponent<SpriteRenderer>().enabled = false;
            timer1.GetComponent<SpriteRenderer>().enabled = true;
        }//if
        else if(player.GetComponent<PlayerController>().rotateCoolDownOn == false)
        {
            rotationArrowIcon.GetComponent<SpriteRenderer>().enabled = true;
            timer1.GetComponent<SpriteRenderer>().enabled = false;
        }//else

        //Toggles between the icon's image and the timer image based on the corresponding cool down (AAJ)
        if (player.GetComponent<PlayerController>().trashCoolDownOn == true)
        {
            trashCanIcon.GetComponent<SpriteRenderer>().enabled = false;
            timer2.GetComponent<SpriteRenderer>().enabled = true;
        }//if
        else if(player.GetComponent<PlayerController>().trashCoolDownOn == false)
        {
            trashCanIcon.GetComponent<SpriteRenderer>().enabled = true;
            timer2.GetComponent<SpriteRenderer>().enabled = false;
        }//else

        //Toggles between the icon's image and the timer image based on the corresponding cool down (AAJ)
        if (player.GetComponent<PlayerController>().basicTurretCoolDownOn == true)
        {
            basicTurretIcon.GetComponent<SpriteRenderer>().enabled = false;
            timer3.GetComponent<SpriteRenderer>().enabled = true;
        }//if
        else if(player.GetComponent<PlayerController>().basicTurretCoolDownOn == false)
        {
            basicTurretIcon.GetComponent<SpriteRenderer>().enabled = true;
            timer3.GetComponent<SpriteRenderer>().enabled = false;
        }//else
    }//ManageToolBar
}
