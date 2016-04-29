using UnityEngine;
using System.Collections;

public class Basic_Turret_Gun : MonoBehaviour {

    //Holds the lasers the turret shoots (AAJ)
    public GameObject laser;

    //Holds the max amount of time the turrent waits to fire (AAJ)
    public int maxShootTimer = 40;

    //Holds the amount of time passed without firing the laser (AAJ)
    private int shootTimer;

    // Use this for initialization
    void Start()
    {

    }

    // Fixed Update is called consistently 
    void FixedUpdate()
    {
        //Fire Lasers (AAJ)
        Lasers();
    }//fixed update

    /// <summary>
    /// Fires lasers when space is pressed (AAJ)
    /// </summary>
    public void Lasers()
    {
        if (shootTimer == maxShootTimer)
        {
            Instantiate(laser, this.transform.position, this.transform.rotation);

            //Resets the shoot timer (AAJ)
            shootTimer = 0;
        }//if

        //Increments the shoot timer (AAJ)
        shootTimer++;

    }//Lasers
}
