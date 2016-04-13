using UnityEngine;
using System.Collections;

public class Title_Screen_Camera : MonoBehaviour {

    //Holds how long the intro screen will last (AAJ)
    public int maxIntroTimer = 150;

    //Holds how much time has passed on the intro screen (AAJ) 
    private int introTimer = 0;

    //Holds where the camera will start the lerp from (AAJ)
    private Vector3 startingPoint;

    //Holds where the camera wil be lerped to (AAJ)
    private Vector3 endingPoint;

    //Holds the speed the camera will lerp at (AAJ)
    public float speed = 50.0f;

    //Holds whether or not the starting time has been set (AAJ)
    public bool startingTimeSet = false;

    //Holds the time the camera started lerping (AAJ)
    private float startingTime;

    //Holds the total distance the camera will travel (AAJ)
    public float totalDistance = 50.0f;

    //Holds the disatnce covered as the camera lerps (AAJ)
    float distanceCoverd;

    //Holds the fraction of the trip completed (AAJ)
    float fractionTrip;

    // Use this for initialization
    void Start ()
    {
        //Gets the starting point of the lerp (AAJ)
        startingPoint = this.transform.position;

        //Sets the ending point of the lerp based on the starting point (AAJ)
        endingPoint = this.transform.position;
        endingPoint.y += totalDistance;

        //Gets the total distance the camera will be lerped (AAJ)
        totalDistance = Vector3.Distance(startingPoint, endingPoint);
	}//start
	
	// Fixed Update is called consistently
	void FixedUpdate()
    {
        //Sets the starting time if it has not been set yet (AAJ)
        if(introTimer == maxIntroTimer && startingTimeSet == false)
        {
            startingTime = Time.time;

            //The start time has been set (AAJ)
            startingTimeSet = true;
        }//if

        if(introTimer == maxIntroTimer)
        {   
            //Keeps track of the distance traveled and the fraction trip that has been completed (AAJ)
            distanceCoverd = (Time.time - startingTime) * speed;
            fractionTrip = distanceCoverd / totalDistance;

            //Updates the postion of the camera (AAJ)
            this.transform.position = Vector3.Lerp(startingPoint, endingPoint, fractionTrip);
        }//if
        else
        {
            //Increment the timer
            introTimer++;
        }
    }//fixed update
}
