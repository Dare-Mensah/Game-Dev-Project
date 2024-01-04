using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully
using TMPro;
using UnityEngine.UI;

public class MovementRunner : MonoBehaviour
{  // the coin class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    public float moveSpeed = 3; //public reference and declaration to the move speed variable which is intialised to a value of 3 secs

    public float left_right_speed = 4; //public reference and declaration of the left right speed which is initialised to a value of 4 secs


    [SerializeField] TextMeshProUGUI _score;
    //present target value on UI
    [SerializeField] TextMeshProUGUI _target;
    //track player score
    public int score = 0; //public reference to the score variable which is initialised to the value of 0
    //value that player acheived
    public int target; //public reference to the variable target
    //message to output if player is winning or not
    public GameObject WinText; //public reference to the game object win text


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed); //moving the player forward

        if(Input.GetKey(KeyCode.A)) //checks if user inputs A as per the getkey function that is utilised here
        { 
            transform.Translate(Vector3.forward * Time.deltaTime * left_right_speed); //moving charcater left

        }
        if (Input.GetKey(KeyCode.D))  //checks if user inputs the character D which is denoted by the key code and obtained by the getkey function
        {
            transform.Translate(Vector3.back * Time.deltaTime * left_right_speed); //moving charcater right
        }


        _score.text = score.ToString("00"); //appends the text value of the variable _score via the use of ToString
        _target.text = target.ToString("00");//appends the text value of the variable _target via the use of ToString


        if (score == target) //checks if the score is equal to target
        {
            score = target; //score is intialised as the target score 
            WinText.SetActive(true); //then sets the win text to be active via the use of setActive()
            //spawner.SetActive(false);
            //spawner.GetComponent<Spawner>().enabled = false;

        }

    }

    private void OnTriggerEnter(Collider other)
    { //method is called and actioned upon should the player enter the trigger collider
        if (other.gameObject.tag == "Item") //CHECKS IF THE BALL INTERACTS WITH THE CUBE THEN INCREMENTS THE SCORE BY 1
        {
            score += 1;//incrementing score by 1 per cube collided with
        }
    }
}
