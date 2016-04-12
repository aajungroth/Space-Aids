using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Holds the player's rigidbody so it can be manipulated (AAJ)
    Rigidbody2D playerBody;

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

	// Use this for initialization
	void Start ()
    {
        //Finds the player (AAJ)
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Moves the player forward (AAJ)
            playerBody.AddForce(transform.up * 1.5f, ForceMode2D.Force);
        }//if

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Moves the player backward (AAJ)
            playerBody.AddForce(transform.up * (-1.0f), ForceMode2D.Force);
        }//if

        //The controls for turning the player (AAJ)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Turns the player left (AAJ)
            playerBody.AddTorque(torque, ForceMode2D.Force);
        }//if

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Turns the player right (AAJ)
            playerBody.AddTorque(-torque, ForceMode2D.Force);
        }//if

    }//MovementControls()
}
