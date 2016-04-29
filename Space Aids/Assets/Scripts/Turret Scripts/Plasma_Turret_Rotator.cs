using UnityEngine;
using System.Collections;

public class Plasma_Turret_Rotator : MonoBehaviour {

    //Holds the player (AAJ)
    private GameObject player;

    // Use this for initialization
    void Start ()
    {
        //Gets the player (AAJ)
        player = GameObject.FindGameObjectWithTag("Player");
    }//start
	
	// Update is called once per frame
	void Update ()
    {
        //If the player exists this turret mirrors the player's rotation (AAJ)
        if (player != null)
        {
            this.transform.rotation = player.transform.rotation;
        }//if
    }//update
}
