using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully
using TMPro;
using UnityEngine.UI; //unity engine UI imported to allow for qualitative features to be deployed effectively
public class CollectItem : MonoBehaviour
{ // the collectItem class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    //track player score
    public int score;
    //value that player acheived
    public int target;
    //display the score to GUI
    [SerializeField] TextMeshProUGUI _score;
    //present target value on UI
    [SerializeField] TextMeshProUGUI _target;
    //message to output if player is winning or not
    public GameObject WinText;
    //responsible for spawning cubes
    public GameObject spawner;
    //camera of this puzzle mini game
    public GameObject puzzleCam;
    //part of the environment
    public GameObject platform;
    //player of this game
    public GameObject ball;
    

    //public Spawner spawn;
    // Start is called before the first frame update
    void Start()
    {
        score = 0; //score is initialised as being 0 so to thus define a clear starting score
        spawner.SetActive(false); //spawner is disable as the setactive() method is utilised to set it to a false state

    }

    // Update is called once per frame
    void Update()
    {
        _score.text = score.ToString("00"); //the score object is initialised to update the text property of the score object
        _target.text = target.ToString("00");  //the target object is initialised to update the text property of the target object

        if(score == target)
        { //a condition based if statement is deployed in order to check whehter the players score is equal to the pre defined target score
            score = target; //score is assigned to target through basic intialisation
            WinText.SetActive(true); //the wintext variable is set to a true state via the use of setActive() method
            //spawner.SetActive(false);
            //spawner.GetComponent<Spawner>().enabled = false;

        }
        
        if(puzzleCam.activeInHierarchy == true) //CHECKS IF THE PUZZLE CAM IS ACTIVE THEN SETS THE SPAWNER TO TRUE
        {
            spawner.SetActive(true); //setactive() method is used to active spawner variable that is resultantly set to being true
        }

        //if(Input.GetKey(KeyCode.Escape))
        //{
            //score = 0;
        //}
    }

    private void OnTriggerEnter(Collider other)
    { //method called should player enter the trigger colliders
        if(other.gameObject.tag == "Item") //CHECKS IF THE BALL INTERACTS WITH THE CUBE THEN INCREMENTS THE SCORE BY 1
        {
            score += 1; //incrementing score by 1 should the player make contact with a cube
        }
    }
}



