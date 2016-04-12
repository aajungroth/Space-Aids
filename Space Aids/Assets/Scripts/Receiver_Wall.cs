using UnityEngine;
using System.Collections;

public class Receiver_Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Objects that enter a receiver cannot be wrapped (AAJ)
    /// </summary>
    /// <param name="Object"></param>
    void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.GetComponent<PlayerObjects>() != null)
        {
            Object.GetComponent<PlayerObjects>().canWrap = false;
        }//if

        if (Object.GetComponent<EnemyManager>() != null)
        {
            Object.GetComponent<EnemyManager>().canWrap = false;
        }//if
    }//OnTriggerEnter2D()

    /// <summary>
    /// Makes sure that objects touching receivers will not warp untill they exit the receiver (AAJ)
    /// </summary>
    /// <param name="Object"></param>
    void OnTriggerExit2D(Collider2D Object)
    {
        if(Object.GetComponent<PlayerObjects>() != null)
        {
            Object.GetComponent<PlayerObjects>().canWrap = true;
        }//if

        if (Object.GetComponent<EnemyManager>() != null)
        {
            Object.GetComponent<EnemyManager>().canWrap = true;
        }//if
    }//OnTriggerExit2D()
}
