using UnityEngine;
using System.Collections;

public class Lasers : MonoBehaviour {

    //Holds how long the laser lasts (AAJ)
    public int maxlaserTimer = 1000;

    //Holds how the long the laser has lasted (AAJ)
    public int laserTimer = 0;

    //Holds how much damage the laser does (AAJ)
    public int damage = -10;

    //Laser speed, tempMousePosition, and direction are for lasers fired by the player (AAJ)

    //Holds the speed of the laser (AAJ)
    public float laserSpeed = 100.0f;

    //Temporarly holds the mouse's position (AAJ)
    private Vector2 tempMousePosition;

    //Holds the direction the laser should go in (AAJ)
    private Vector2 direction;

    //Holds whether or not the player fired the laser (AAJ)
    public bool fromPlayer = false;

    // Use this for initialization
    void Start()
    {
        //Only the player's lasers shoot towards the mouse (AAJ)
        if (fromPlayer == true)
        {
            //This gets the mouse's location (AAJ)
            tempMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Gets the direction (AAJ)
            direction = this.transform.position;
            direction = tempMousePosition - direction;

            //This normalizes the direction (AAJ)
            direction.Normalize();

            //This is for lasers fired from turrets (AAJ)
            this.GetComponent<Rigidbody2D>().AddForce(direction * laserSpeed);
        }//if
    }//Start

    //Update is called once per frame
    void Update()
    {
        //This shoots the lasers foward (AAJ)
        if (fromPlayer == false)
        {
            //This is for lasers fired from turrets (AAJ)
            this.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up, ForceMode2D.Impulse);
        }//else

        //Destroys the laser after a set time (AAJ)
        if (laserTimer == maxlaserTimer)
        {
            Destroy(this.gameObject);
        }//if

        //Increments the timer (AAJ)
        laserTimer++;

	}//Update

    /// <summary>
    /// Subtracs health from enemies that it hits (AAJ)
    /// </summary>
    /// <param name="Object"></param>
    void OnTriggerEnter2D(Collider2D Object)
    {
        if(Object.GetComponent<EnemyManager>() != null)
        {
            Object.GetComponent<EnemyManager>().alterHealth(damage);

            //Removes the laser after it hits something (AAJ)
            Destroy(this.gameObject);
        }//if
    }//Ontriggerenter()
}
