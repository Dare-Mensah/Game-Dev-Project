using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Manager : MonoBehaviour
{

    public GameObject puzzleCam;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleCam.activeInHierarchy == true)
        {
            ball.SetActive(true);
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            ball.SetActive(false);
        }
    }
}
