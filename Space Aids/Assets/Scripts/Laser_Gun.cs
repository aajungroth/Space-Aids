using UnityEngine;
using System.Collections;

public class Laser_Gun : MonoBehaviour {
    
    //Holds the lasers the player shoots (AAJ)
    public GameObject laser;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Fire Lasers (AAJ)
        Lasers();
    }

    /// <summary>
    /// Fires lasers when space is pressed
    /// </summary>
    public void Lasers()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laser, this.transform.position, this.transform.rotation);
        }//if
    }//Lasers
}
