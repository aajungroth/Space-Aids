using UnityEngine;
using System.Collections;

public class Laser_Gun : MonoBehaviour {
    
    //Holds the lasers the player shoots (AAJ)
    public GameObject laser;

    //A timer that has the time since the last laser was fired (AAJ)
    private float shotTime;

    //A timer to prevent the lasers from being spammed (AAJ)
    private float reloadTimer = 0.25f;

    //The amount of time before the gun can be fired (AAJ)
    public float reloadTimeLimit = 0.25f;

    //Controls whether the laser gun is firing or not (AAJ)
    public bool isFiring = false;

    // Use this for initialization
    void Start () {
	
	}

    //Fixed Update is called consistently
    void FixedUpdate()
    {
        //Fire Lasers (AAJ)
        Lasers();
    }//FixedUpdate()

    /// <summary>
    /// Fires lasers when space is pressed
    /// </summary>
    public void Lasers()
    {
        //Toggels whether or not the laser gun is firing (AAJ)
        if((Input.GetKeyDown(KeyCode.Mouse0)) || (Input.GetKeyDown(KeyCode.Space)))
        {
            if(isFiring == true)
            {
                isFiring = false;
            }//if
            else
            {
                isFiring = true;
            }//else
        }//if

        //Can only fire once the laser gun has reloaded (AAJ)
        if (reloadTimer >= reloadTimeLimit)
        {
            //Fires when the left mouse button is pressed or held down (AAJ)
            if(isFiring == true)
            {
                //Spawns a laser (AAJ)
                Instantiate(laser, this.transform.position, this.transform.rotation);

                //Records when the laser was fired (AAJ)
                shotTime = Time.time;

                //Resets reloadTimer
                reloadTimer = 0;
            }//if
        }//if
        else
        {
            //Updates the reloadTimer (AAJ)
            reloadTimer = Time.time - shotTime;
        }//else
    }//Lasers
}
