using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health_Bar_Script : MonoBehaviour {

    //Hols the player object that the health bar is tracking (AAJ)
    public PlayerObjects playerObject;

    //Holds a health bar that will be adjust to the health of the player object it is following (AAJ)
    public Image bar;

    //Holds a background that lerps to match the health bar (AAJ)
    public Image background;

    //Holds the current health value of the player object (AAJ)
    private float currentHealth;

    //Holds the health value the player object started with (AAJ)
    private float startingHealth;

    //Holds the starting size of the x scaling for the bar (AAJ)
    private float barSize;

    //Hols the rate that the background lerps (AAJ)
    public float backgroundLerpRate = 10.0f;

	//Use this for initialization
	void Start()
    {
        //Runs if there is a reference to a player object and a health bar (AAJ)
        if(playerObject != null)
        {
            startingHealth = playerObject.health;
            barSize = bar.transform.localScale.x;
        }//if
	}//Start

    //Fixed Update is called consistently 
    void FixedUpdate()
    {
        //Runs if there is a reference to a player object (AAJ)
        if (playerObject != null)
        {
            //Gets the health as a decimal value (AAJ)
            currentHealth = playerObject.health / startingHealth;

            //If the currentHealth is a negative value set it to zero (AAJ)
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }//if
        }//if
        else
        {
            //If there is no player object then the player object's health is considerd to be zero (AAJ)
            currentHealth = 0;
        }//else

        //Runs if there is a reference to a health bar, and a health bar background (AAJ)
        if (bar != null && background != null)
        {
            //Adjusts the health bar to represent the player objects health (AAJ)
            bar.transform.localScale = new Vector3(barSize * currentHealth, bar.transform.localScale.y, bar.transform.localScale.z);

            //Lerps the background to the current size of the health bar (AAJ)
            background.transform.localScale = Vector3.Lerp(background.transform.localScale, bar.transform.localScale, backgroundLerpRate * Time.deltaTime);
        }//if
	}//Update
}
