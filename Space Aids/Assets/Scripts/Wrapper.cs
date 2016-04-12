using UnityEngine;
using System.Collections;

public class Wrapper : MonoBehaviour {

    //Holds the wall that the colliding object will be moved to (AAJ)
    public GameObject OtherWall;

    //Holds a temporary vector2 for the y position of the other wall (AAJ)
    private Vector2 temp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    /// <summary>
    /// Warps objects to the other wall (AAJ)
    /// </summary>
    /// <param name="Object"></param>
    void OnTriggerExit2D(Collider2D Object)
    {
        //Holds whether the object can be wrapped or not (AAJ)
        bool canWrap = true;
        
        //Makes sure that the receiver wall exists (AAJ)
        if (OtherWall != null)
        {
            //Determines if the object can be wrapped (AAJ)
            if (Object.GetComponent<PlayerObjects>() != null)
            {
                canWrap = Object.GetComponent<PlayerObjects>().canWrap;
            }//if

            if (Object.GetComponent<EnemyManager>() != null)
            {
                canWrap = Object.GetComponent<EnemyManager>().canWrap;
            }//if

            //Only wraps objects that are not touching the receivers (AAJ)
            if(canWrap == true)
            {
                temp = Object.transform.position;
                temp.x = OtherWall.transform.position.x;
                Object.transform.position = temp;
            }//if
        }//if
    }//OnTriggerExit2D()
}
