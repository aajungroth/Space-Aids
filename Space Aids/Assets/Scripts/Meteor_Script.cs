using UnityEngine;
using System.Collections;

public class Meteor_Script : MonoBehaviour {

    //Holds the health manager for the enemy (AAJ)
    public EnemyManager enemyManager;

    //Holds if the meteor will move forward (AAJ)
    public bool moveForward = true;

    //Holds the size of the meteor (AAJ)
    public int size;

    //Holds the damage the meteor does (AAJ)
    public int damage = -100;

    //Hold the different sizes of meteor (AAJ)
    public GameObject colossalMeteor;
    public GameObject extraLargeMeteor;
    public GameObject largeMeteor;
    public GameObject meteor;
    public GameObject smallMeteor;

    //Holds the meteor of the correct size to be instantiated (AAJ)
    private GameObject meteorHalf;
    
    //Hold the instances of meteor halves (AAJ)
    private GameObject newMeteorLeftHalf;
    private GameObject newMeteorRightHalf;

    //Hold the movement vectors for the meteor halves (AAJ)
    private Vector2 moveLeft;
    private Vector2 moveRight;

    //Holds the movement for whole meteors (AAJ)
    private Vector2 moveStraight;

    // Use this for initialization
    void Start ()
    {
        //Initializes the movement vectors (AAJ)
        moveLeft = new Vector2(-0.5f, -0.5f);
        moveRight = new Vector2(0.5f, -0.5f);
        moveStraight = new Vector2(0.0f, -0.5f);

        //Moves the meteor forward (AAJ)
        if(moveForward == true)
        {
            this.GetComponent<Rigidbody2D>().AddForce(moveStraight, ForceMode2D.Impulse);
        }//if
    }
	
	// Update is called once per frame
	void Update () {
        //If the enemy's health is zero, destroy the enemy (AAJ)
        if(enemyManager.health <= 0)
        {
            //Instantiates two smaller meteors that move forward at 45 degree angles (AAJ)
            splitMeteor();
            Destroy(this.gameObject);
        }//if
    }

    /// <summary>
    /// Instantiates two smaller meteors that move forward at 45 degree angles (AAJ)
    /// </summary>
    public void splitMeteor()
    {
        //Instantiates the next smaller size of meteor (AAJ)
        if (size == 4)
        {
            meteorHalf = extraLargeMeteor;
        }//if
        else if(size == 3)
        {
            meteorHalf = largeMeteor;
        }//if
        else if(size == 2)
        {
            meteorHalf = meteor;
        }//if
        else if(size == 1)
        {
            meteorHalf = smallMeteor;
        }//if

        //The small meteor does not split into smaller meteors (AAJ)
        if(size != 0)
        {
            //Instantiates the meteor halves (AAJ)
            newMeteorLeftHalf = Instantiate(meteorHalf, this.transform.position, this.transform.rotation) as GameObject;
            newMeteorRightHalf = Instantiate(meteorHalf, this.transform.position, this.transform.rotation) as GameObject;

            //Prevents the meteors from moving forward (AAJ)
            newMeteorLeftHalf.GetComponent<Meteor_Script>().moveForward = false;
            newMeteorRightHalf.GetComponent<Meteor_Script>().moveForward = false;

            //Moves the meteors in 45 degree angles (AAJ)
            newMeteorLeftHalf.GetComponent<Rigidbody2D>().AddForce(moveLeft, ForceMode2D.Impulse);
            newMeteorRightHalf.GetComponent<Rigidbody2D>().AddForce(moveRight, ForceMode2D.Impulse);
        }//if
    }//splitMeteor

    /// <summary>
    /// Does damage to objects it hits (AAJ)
    /// </summary>
    /// <param name="Object"></param>
    void OnTriggerEnter2D(Collider2D Object)
    {
        //If the colliding object is a player object deal damage (AAJ)
        if(Object.GetComponent<PlayerObjects>() == true)
        {
            Object.GetComponent<PlayerObjects>().alterHealth(damage);
        }//if
    }//OnTriggerEnter2D
}
