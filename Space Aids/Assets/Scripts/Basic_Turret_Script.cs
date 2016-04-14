using UnityEngine;
using System.Collections;

public class Basic_Turret_Script : MonoBehaviour {

    //Holds the index number of this turret (AAJ)
    public int turretIndex = 0;

    //Holds the cost of the turret (AAJ)

    //Holds the player object (AAJ)
    private PlayerObjects playerObjects;

    //Holds the player for collision detections (AAJ)
    private PlayerController playerController;

    //Holds the target circle for when the player mouses over the turret (AAJ)
    public GameObject targetingCircle;

    // Use this for initialization
    void Start()
    {
        //Gets the turret's player object for managing health (AAJ)
        playerObjects = this.GetComponent<PlayerObjects>();

        //Finds the player (AAJ)
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }//start

    // Update is called once per frame
    void Update()
    {
        //The turret is destroyed when it runs out of health (AAJ)
        if(playerObjects != null)
        {
            if (playerObjects.health <= 0)
            {
                Destroy(this.gameObject);
            }//if
        }//if
    }//update

    //Detects when the player targets a basic turret (AAJ)
    void OnMouseEnter()
    {
        if(playerController != null)
        {
            playerController.isTargeting = true;

            //Turns on the targeting circle (AAJ)
            targetingCircle.SetActive(true);

            //Lets the player know which turret the player is targeting (AAJ)
            playerController.targetedTurret = this.gameObject;

        }//if
    }//OnMouseEnter

    //Detects when the player stops targeting a basic turret (AAJ)
    void OnMouseExit()
    {
        if (playerController != null)
        {
            playerController.isTargeting = false;

            //Turns off the targeting circle (AAJ)
            targetingCircle.SetActive(false);
        }//if
    }//OnMouseExit
}
