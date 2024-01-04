using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine;

public class MazePuzzleManager : MonoBehaviour
{// mazepuzzlemanager class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features


    public GameObject puzzleCam; //a reference to the camera that is utilised for the puzzle 
    public GameObject Ball; //reference to the ball 

    public GameObject rocks;
    public GameObject winText; //reference to win text that indicates successfull completion of game
    public GameObject loseText; //reference to lose text that indicates unsuccessful completion of game
    // Update is called once per frame
    void Update()
    {
        if(puzzleCam.activeInHierarchy == true) //checks if the puzzleCam is active
        {
            Ball.SetActive(true); //this sets the ball to be true and thus activated
            rocks.SetActive(true); //this sets the rock to be true and thus activated
        }

        if(winText.activeInHierarchy ==true)
        { //a condition based checkk to see if the win text is currently active within the science
            rocks.SetActive(false);
        }
        else if(loseText.activeInHierarchy ==true)
        { //condition based check to see if lose text is active which would indicate player has an unsuccessful attempt
            rocks.SetActive(false); //setting the rock to be inactive
        }
    }
}
