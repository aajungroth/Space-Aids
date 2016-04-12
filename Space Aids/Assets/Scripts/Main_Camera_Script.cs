using UnityEngine;
using System.Collections;

public class Main_Camera_Script : MonoBehaviour {

    //Gets the player so the camera can track the player's movement (AAJ)
    private GameObject player;

    //Holds the initial position of the camera (AAJ)
    private float initialPosition;

    //A temporary vector2 for getting the players y postion (AAJ)
    private Vector3 temp;

	// Use this for initialization
	void Start()
    {
        //Gets the player (AAJ)
        player = GameObject.FindGameObjectWithTag("Player");

        //Initializes the intial position (AAJ)
        initialPosition = this.transform.position.y;
	}//start

    // Late Update is called after other updates run
    void LateUpdate()
    {
        //If the player has been found (AAJ)
        if(player != null)
        {
            //Moves the camera with the player in the y direction as long as the camera does not go above its orginal position (AAJ)
            if (player.transform.position.y <= initialPosition)
            {
                temp = this.transform.position;
                temp.y = player.transform.position.y;
                this.transform.position = temp;
            }//if
        }//if
	}//late update
}
