using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Check : MonoBehaviour
{

    public GameObject puzzleCam;

    public GameObject playerPuzzle3;

    // Start is called before the first frame update
    void Start()
    {
        playerPuzzle3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleCam.activeInHierarchy == true)
        {
            playerPuzzle3.SetActive(true);
        }
    }
}
