using UnityEngine;
using System.Collections;

public class Target_Rotator_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Fixed Update is called consistently
	void FixedUpdate ()
    {
        transform.Rotate(0, 0, -20 * Time.deltaTime);
	}//fixed update
}
