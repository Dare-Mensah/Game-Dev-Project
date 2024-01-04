using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully


public class Puzzle2Manager : MonoBehaviour
{ // the puzzle2manager class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features


    public GameObject puzzleCam; //public reference to the game obj puzzle cam
    public GameObject ball; //public reference to the game object ball
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleCam.activeInHierarchy == true) // A condition based check utilising the if statement to check whether the camera is on aka true
        {
            ball.SetActive(true); //the ball is activated and set a true state via the use of setActive() that makes this possible
        }

        //if(Input.GetKey(KeyCode.Escape))
        //{
            //ball.SetActive(false);
        //}
    }
}
