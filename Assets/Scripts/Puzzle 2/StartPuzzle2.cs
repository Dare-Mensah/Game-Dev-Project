using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPuzzle2 : MonoBehaviour
{
    //the camera inside the puzzle
    public GameObject puzzleCam;
    //primary camera attached to the player
    public GameObject playerCam;
    //player who is moving
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //check E bottom is pressed
        if(Input.GetKeyDown(KeyCode.E))
        {
            //make puzzle camera,and player in minigame on, rest turns off, to prevent player in big map is affect by control.
            puzzleCam.SetActive(true);
            player.SetActive(false);
            playerCam.SetActive(false);
        }
    }
    //this game is inspired by video https://www.youtube.com/watch?v=gkBntY22Oco
}
