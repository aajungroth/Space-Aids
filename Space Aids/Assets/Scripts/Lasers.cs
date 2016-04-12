using UnityEngine;
using System.Collections;

public class Lasers : MonoBehaviour {

    //Holds how long the laser lasts (AAJ)
    public int maxlaserTimer = 1000;

    //Holds how the long the laser has lasted (AAJ)
    public int laserTimer = 0;

    //Holds how much damage the laser does (AAJ)
    public int damage = -10;

	// Use this for initialization
	void Start () {
        
    }//start
	
	// Update is called once per frame
	void Update () {

        //This shoots the bullets foward (AAJ)
        this.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up, ForceMode2D.Impulse);

        //Destroys the laser after a set time (AAJ)
        if (laserTimer == maxlaserTimer)
        {
            Destroy(this.gameObject);
        }//if

        //Increments the timer (AAJ)
        laserTimer++;

	}//update

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
