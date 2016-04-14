using UnityEngine;
using System.Collections;

public class Basic_Turret_Script : MonoBehaviour {

    //Holds the index number of this turret (AAJ)
    public int turretIndex = 0;

    //Holds the player object (AAJ)
    private PlayerObjects playerObjects;

    // Use this for initialization
    void Start()
    {
        //Gets the turret's player object for managing health (AAJ)
        playerObjects = this.GetComponent<PlayerObjects>();
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
}
