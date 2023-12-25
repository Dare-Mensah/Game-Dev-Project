using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Check : MonoBehaviour
{
    //camera specific to a puzzle
    public GameObject puzzleCam;
    // the player who is playing
    public GameObject playerPuzzle3;

    // Start is called before the first frame update
    void Start()
    {
        playerPuzzle3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleCam.activeInHierarchy == true) //check if the puzzle cam is active then sets the puzzle player to active
        {
            playerPuzzle3.SetActive(true);
        }
    }
    // this game is inspired by website https://gamedevacademy.org/unity-ski-mini-game-tutorial/
}
