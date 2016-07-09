using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    //Enemy Health (AAJ)
    public int health = 100;

    //Holds whether or not the object is touching a wrapping wall receiver (AAJ)
    public bool canWrap = true;

    //Holds whether or not the enemies health is being changed over time (AAJ)
    private bool isHealthChangingOverTime = false;

    //Holds the health over time done to the enemy (AAJ)
    private int healthOverTime = 0;

    // Use this for initialization
    void Start () {
	    
	}//start
	
	// Update is called once per frame
	void Update ()
    {
        
	}//update

    // Fixed Update is called consistently 
    void FixedUpdate()
    {
        if (isHealthChangingOverTime)
        {
            health += healthOverTime;
        }//if

        isHealthChangingOverTime = false;
    }//fixed update

    /// <summary>
    /// Changes the health of the enemy as it interacts with other objects (AAJ)
    /// </summary>
    /// <param name="hp"></param>
    public void alterHealth(int hp)
    {
        //Adds the change in hp to health (AAJ)
        health += hp;
    }//alterHealth

    /// <summary>
    /// Changes the health of the enemy as it interacts with other objects over time (AAJ)
    /// </summary>
    /// <param name="hp"></param>
    public void alterHealthOverTime(bool isHealthAltered, int hp)
    {
        //Sets whether or not the enemies health is changing over time (AAJ)
        isHealthChangingOverTime = isHealthAltered;

        //Sets the healthOverTime to hp (AAJ)
        healthOverTime = hp;
    }//alterHealth
}
