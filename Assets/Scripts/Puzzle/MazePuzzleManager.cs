using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePuzzleManager : MonoBehaviour
{

    public GameObject puzzleCam;
    public GameObject Ball;

    // Update is called once per frame
    void Update()
    {
        if(puzzleCam.activeInHierarchy == true) //checks if the puzzleCam is active
        {
            Ball.SetActive(true); //sets teh abll to true
        }
    }
}
