using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully

public class Puzzle3Check : MonoBehaviour
{ // the puzzle3check class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    //camera specific to a puzzle
    public GameObject puzzleCam; //public reference made to game object puzzle cam
    // the player who is playing
    public GameObject playerPuzzle3; //public reference made to game object player puzzle 3

    // Start is called before the first frame update
    void Start()
    {
        playerPuzzle3.SetActive(false); //setActive() method sets the game object player puzzle 3 to false
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleCam.activeInHierarchy == true) //check if the puzzle cam is active then sets the puzzle player to active
        {
            playerPuzzle3.SetActive(true); //setActive() method sets the game object player puzzle 3 to true
        }
    }
    // this game is inspired by website https://gamedevacademy.org/unity-ski-mini-game-tutorial/
}
