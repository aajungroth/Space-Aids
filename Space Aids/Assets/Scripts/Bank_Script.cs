using UnityEngine;
using System.Collections;

public class Bank_Script : MonoBehaviour {

    //The amount of money the player has (AAJ)
    public int playerFunds = 0;

    //The amound of money that the basic turret costs (AAJ)
    public int basicTurret = 40;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //The player gets money from defeated enemies (AAJ)
    public void income(int money)
    {
        //Increases the players total funds (AAJ)
        playerFunds += money;
    }//income

    /// <summary>
    /// Used by the player to buy turrets
    /// </summary>
    public bool purchaseTurret(int index)
    {
        //Tests the with the given index number to see if the player has enough money (AAJ)
        switch(index)
        {
            case 0:
                //The Basic Turret (AAJ)
                if(playerFunds >= basicTurret)
                {
                    playerFunds -= basicTurret;
                    return true;
                }//if
            break;

            default:
                //If the index number is not valid (AAJ)
                return false;
            //break;
        }

        //If the player does not have enought money to buy a turret (AAJ)
        return false;
    }//purchaseTurret

    
    public void refundTurret(int index)
    {
        //Tests the with the given index number to see if the player has enough money (AAJ)
        switch (index)
        {
            case 0:
                //The Basic Turret (AAJ)
                playerFunds += basicTurret;
            break;

            default:
                //If the index number is not valid (AAJ)
                
            break;
        }
    }//refundTurret
}
