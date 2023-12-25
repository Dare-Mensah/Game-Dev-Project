using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Manager : MonoBehaviour
{
    //camera for a puzzle
    public GameObject puzzleCam;
    //player in game
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleCam.activeInHierarchy == true) // IF THE PUZZLE CAM IS ON
        {
            ball.SetActive(true); //SETS THE BALL TO TRUE
        }

        //if(Input.GetKey(KeyCode.Escape))
        //{
            //ball.SetActive(false);
        //}
    }
}
