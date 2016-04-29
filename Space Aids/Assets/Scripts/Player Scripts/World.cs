using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

    //Holds the player objects script to get the world's health (AAJ)
    public PlayerObjects playerObject;

	// Use this for initialization
	void Start ()
    {
	
	}//start
	
	// Update is called once per frame
	void Update ()
    {
        //If the world's health goes down to zero, the world is destroyed (AAJ)
        if (playerObject.health <= 0)
        {
            Destroy(this.gameObject);
        }//if
	}//update
}
