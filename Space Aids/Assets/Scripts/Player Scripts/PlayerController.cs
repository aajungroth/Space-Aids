﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    //Holds the player's rigidbody so it can be manipulated (AAJ)
    Rigidbody2D playerBody;

    //Holds the players portait (AAJ)
    private GameObject playerPortrait;

    //Holds the player object (AAJ)
    private PlayerObjects playerObjects;

    //Holds the bank the player uses to buy things (AAJ)
    private Bank_Script bank;
    
    //Hold the turrets the player can spawn (AAJ)
    public GameObject basicTurret;
    public GameObject plasmaTurret;

    //Holds the player's sprites (AAJ)
    public Sprite pinkShip;
    public Sprite blueShip;

    //Holds whether no the sprite will change (AAJ)
    public bool flashProtection = true;

    //Holds how high count needs to go before the sprites will change (AAJ)
    public int maxSpriteTimer = 20;

    //Holds the counter for alternating the sprites (AAJ)
    private int spriteTimer = 0;

    //Holds the troque for the player's turning (AAJ)
    float torque = 0.1f;

    //Holds whether or not the player is targeting a turret with the mouse (AAJ)
    public bool isTargeting = false;

    //Holds the turret that the player is targeting (AAJ)
    public GameObject targetedTurret;

    //Holds whether or not the cool downs are active (AAJ)
    public bool basicTurretCoolDownOn = false;
    public bool plasmaTurretCoolDownOn = false;
    public bool rotateCoolDownOn = false;
    public bool trashCoolDownOn = false;

    //Holds the timer variables for cool downs (AAJ)
    public float basicTurretCoolDown = 1;
    private float basicTurretTimer;
    public float plasmaTurretCoolDown = 3;
    private float plasmaTurretTimer;
    public float rotateCoolDown = 1;
    private float rotateTimer;
    public float trashCoolDown = 1;
    private float trashTimer;

	// Use this for initialization
	void Start ()
    {
        //Finds the player (AAJ)
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        //Finds the player portrait (AAJ)
        playerPortrait = GameObject.FindGameObjectWithTag("Player Portrait") as GameObject;

        //Gets the player's player object for managing health (AAJ)
        playerObjects = this.GetComponent<PlayerObjects>();

        //Finds the bank (AAJ)
        bank = GameObject.FindGameObjectWithTag("Bank").GetComponent<Bank_Script>();
	}//start

    // Fixed Update is called consistently 
    void FixedUpdate () {
        if(playerBody != null)
        {
            //Only changes sprites if their is no flash protection (AAJ)
            if (flashProtection == false)
            {
                //Manages the player's sprites (AAJ)
                SpriteManager();
            }//if

            //Handles the movement (AAJ)
            MovementControls();

            //Spawns in turrets on key presses (AAJ)
            SpawnTurrets();

            //Handles actions that can be done to the turrets (AAJ)
            ActionManager();

            //The player dies if there health is lowered to zero (AAJ)
            if(playerObjects != null)
            {
                if(playerObjects.health <= 0)
                {
                    Debug.Log("Game Over");
                }//if
            }//if

            //If the escape key pressed the title screen will be loaded (AAJ)
            if(Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Title Scene");
            }//if

        }//if
	}//fixed update

    /// <summary>
    /// Alternates between the player's two sprites for a flashing effect (AAJ)
    /// </summary>
    void SpriteManager()
    {
        if((playerBody.GetComponent<SpriteRenderer>().sprite == pinkShip) && (spriteTimer == maxSpriteTimer))
        {
            playerBody.GetComponent<SpriteRenderer>().sprite = blueShip;

            //Resets count (AAJ)
            spriteTimer = 0;
        }//if
        else if((playerBody.GetComponent<SpriteRenderer>().sprite == blueShip) && (spriteTimer == maxSpriteTimer))
        {
            playerBody.GetComponent<SpriteRenderer>().sprite = pinkShip;

            //Resets count (AAJ)
            spriteTimer = 0;
        }//else if

        //Updates sprite count (AAJ)
        spriteTimer++;
    }//SpriteManager()

    /// <summary>
    /// The controls for the player (AAJ)
    /// </summary>
    void MovementControls()
    {
        //The controls for moving the player forward and backward (AAJ)
        if (Input.GetKey(KeyCode.W))
        {
            //Moves the player forward (AAJ)
            playerBody.AddForce(transform.up * 1.5f, ForceMode2D.Force);
        }//if

        if (Input.GetKey(KeyCode.S))
        {
            //Moves the player backward (AAJ)
            playerBody.AddForce(transform.up * (-1.0f), ForceMode2D.Force);
        }//if

        //The controls for turning the player (AAJ)
        if (Input.GetKey(KeyCode.A))
        {
            //Turns the player left (AAJ)
            playerBody.AddTorque(torque, ForceMode2D.Force);
        }//if

        if (Input.GetKey(KeyCode.D))
        {
            //Turns the player right (AAJ)
            playerBody.AddTorque(-torque, ForceMode2D.Force);
        }//if

    }//MovementControls()

    /// <summary>
    /// Manages the spawning of turrets (AAJ)
    /// </summary>
    void SpawnTurrets()
    {
        //Does not except button presses if the cool down is on (AAJ)
        if(basicTurretCoolDownOn == false)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                if(bank.purchaseTurret(basicTurret.GetComponent<Turret_Object_Script>().turretIndex))
                {
                    Instantiate(basicTurret, this.transform.position, this.transform.rotation);

                    //Sets the cool down annd the timer (AAJ)
                    basicTurretCoolDownOn = true;
                    basicTurretTimer = Time.time;
                }//if
            }//if
        }//if
        else
        {
            //If the time has elapsed then the cool down is over (AAJ)
            if(Time.time - basicTurretTimer >= basicTurretCoolDown)
            {
                basicTurretCoolDownOn = false;
            }//if
        }//else

        //Does not except button presses if the cool down is on (AAJ)
        if (plasmaTurretCoolDownOn == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (bank.purchaseTurret(plasmaTurret.GetComponent<Turret_Object_Script>().turretIndex))
                {
                    Instantiate(plasmaTurret, this.transform.position, this.transform.rotation);

                    //Sets the cool down annd the timer (AAJ)
                    plasmaTurretCoolDownOn = true;
                    plasmaTurretTimer = Time.time;
                }//if
            }//if
        }//if
        else
        {
            //If the time has elapsed then the cool down is over (AAJ)
            if (Time.time - plasmaTurretTimer >= plasmaTurretCoolDown)
            {
                plasmaTurretCoolDownOn = false;
            }//if
        }//else

    }//SpawnTurrets

    /// <summary>
    /// Manages the actions players can do to turrets (AAJ)
    /// </summary>
    void ActionManager()
    {
        //Does not except button presses if the cool down is on (AAJ)
        if(rotateCoolDownOn == false)
        {
            //Makes sure the player is targeting a turret (AAJ)
            if(isTargeting == true && targetedTurret != null)
            {
                //Rotates the turret the player is targeting (AAJ)
                if(Input.GetKeyDown(KeyCode.R))
                {
                    targetedTurret.transform.rotation = this.transform.rotation;

                    //Sets the cool down annd the timer (AAJ)
                    rotateCoolDownOn = true;
                    rotateTimer = Time.time;
                }//if
            }//if
        }//if
        else
        {
            //If the time has elapsed then the cool down is over (AAJ)
            if(Time.time - rotateTimer >= rotateCoolDown)
            {
                rotateCoolDownOn = false;
            }//if
        }//else

        //Does not except button presses if the cool down is on (AAJ)
        if(trashCoolDownOn == false)
        {
            //Makes sure the player is targeting a turret (AAJ)
            if (isTargeting == true && targetedTurret != null)
            {
                //Destroys the turret and refunds the player (AAJ)
                if (Input.GetKeyDown(KeyCode.T))
                {
                    //The player is no longer targeting the turret that was destroyed (AAJ)
                    isTargeting = false;

                    //Refunds the player (AAJ)
                    bank.refundTurret(targetedTurret.GetComponent<Turret_Object_Script>().turretIndex);

                    //Destroys the turret (AAJ)
                    Destroy(targetedTurret);

                    //Sets the cool down annd the timer (AAJ)
                    trashCoolDownOn = true;
                    trashTimer = Time.time;
                }//if
            }//if
        }//if
        else
        {
            //If the time has elapsed then the cool down is over (AAJ)
            if(Time.time - trashTimer >= trashCoolDown)
            {
                trashCoolDownOn = false;
            }//if
        }//else
    }//ActionManager
}