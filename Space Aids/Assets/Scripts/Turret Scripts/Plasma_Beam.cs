using UnityEngine;
using System.Collections;

public class Plasma_Beam : MonoBehaviour {

    //Holds whether or not the beam is doing damage (AAJ)
    private bool isHitting = false;

    //Holds hte damage the beam does (AAJ)
    public int damage = -1;

	// Use this for initialization
	void Start ()
    {
	
	}

    // Update is called once per frame
    void Update()
    {

    }//update

    /// <summary>
    /// Enemies who touch the stream take damage (AAJ)
    /// </summary>
    /// <param name="Object"></param>
    void OnTriggerEnter2D(Collider2D Object)
    {
        //If the enemy exists (AAJ)
        if(Object.GetComponent<EnemyManager>() != null)
        {
            //The beam is doing damage (AAJ)
            isHitting = true;

            //Alters the enemies health over time (AAJ)
            Object.GetComponent<EnemyManager>().alterHealthOverTime(isHitting, damage);
        }//if
    }//OnTriggerEntrance2D()

    /// <summary>
    /// Enemies stop taking damage when they exit the stream (AAJ)
    /// </summary>
    /// <param name="Object"></param>
    void OnTriggerExit2D(Collider2D Object)
    {
        //If the enemy exists (AAJ)
        if (Object.GetComponent<EnemyManager>() != null)
        {
            //The beam is not doing damage (AAJ)
            isHitting = false;

            //Alters the enemies health over time (AAJ)
            Object.GetComponent<EnemyManager>().alterHealthOverTime(isHitting, 0);
        }//if
    }//OnTriggerExit2D()
}
