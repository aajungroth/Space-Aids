using UnityEngine;
using System.Collections;

public class PlayerObjects : MonoBehaviour {

    //The player object's health
    public float health = 100;

    //Holds whether or not the object is touching a wrapping wall receiver (AAJ)
    public bool canWrap = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Changes the health of the player object as it interacts with other objects (AAJ)
    /// </summary>
    /// <param name="hp"></param>
    public void alterHealth(int hp)
    {
        //Adds the change in hp to health (AAJ)
        health += hp;
    }//alterHealth
}
