using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenUI_Script : MonoBehaviour {

    //Holds the main camera's move controls so the UI can react to the camera (AAJ)
    private Title_Screen_Camera title_Screen_Camera;

    //Holds the production text (AAJ)
    public Text productionText;

    //Holds the first half of the title (AAJ)
    public Text firstHalf;

    //Holds the second half of the title (AAJ)
    public Text secondHalf;

    //Holds the start button (AAJ)
    public GameObject startButton;

    //Holds the exit button (AAJ)
    public GameObject exitButton;

	// Use this for initialization
	void Start ()
    {
        //Starts by disabling the title screen (AAJ)
        firstHalf.enabled = false;
        secondHalf.enabled = false;
        startButton.SetActive(false);
        exitButton.SetActive(false);

        //Gets the title screen camera
        title_Screen_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Title_Screen_Camera>();
	}//Start
	
	// Update is called once per frame
	void Update ()
    {
        //If the camera has started moving disable the production text (AAJ)
	    if(title_Screen_Camera.startingTimeSet == true)
        {
            productionText.enabled = false;
        }//if

        //If the camera has stopped moving enable the title screen (AAJ)
        if(title_Screen_Camera.gameObject.transform.position.y == title_Screen_Camera.totalDistance)
        {
            firstHalf.enabled = true;
            secondHalf.enabled = true;
            startButton.SetActive(true);
            exitButton.SetActive(true);
        }//if

	}//Update

    /// <summary>
    /// Starts the game (AAJ)
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("DemoLevel");
    }//StartGame()

    /// <summary>
    /// Ends the game (AAJ)
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }//ExitGame()
}
