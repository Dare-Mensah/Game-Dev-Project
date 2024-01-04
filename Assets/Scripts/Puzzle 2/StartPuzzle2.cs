using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully

public class StartPuzzle2 : MonoBehaviour
{  // the startpuzzle2 class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    //the camera inside the puzzle
    public GameObject puzzleCam; //public reference made to the game object puzzle cam
    //primary camera attached to the player
    public GameObject playerCam; //public reference made to the game object player camera
    //player who is moving
    public GameObject player; //public reference to the game object player
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    { //method is called as the player enters the trigger collider
        //check E bottom is pressed
        if(Input.GetKeyDown(KeyCode.E))
        { //condition based check to see if input corresponds to the key "E" which invokes proceeding code
            //make puzzle camera,and player in minigame on, rest turns off, to prevent player in big map is affect by control.
            puzzleCam.SetActive(true);//setActive() method is used to set the puzzlecam to false 
            player.SetActive(false); //setActive() method is used to set the player to false 
            playerCam.SetActive(false); //setActive() method is used to set the playercam to false 
        }
    }
    //this game is inspired by video https://www.youtube.com/watch?v=gkBntY22Oco
}
