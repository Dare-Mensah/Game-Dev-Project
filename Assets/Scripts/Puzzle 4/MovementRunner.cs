using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovementRunner : MonoBehaviour
{
    public float moveSpeed = 3;

    public float left_right_speed = 4;


    [SerializeField] TextMeshProUGUI _score;
    //present target value on UI
    [SerializeField] TextMeshProUGUI _target;
    //track player score
    public int score = 0;
    //value that player acheived
    public int target;
    //message to output if player is winning or not
    public GameObject WinText;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed); //moving the player forward

        if(Input.GetKey(KeyCode.A)) //checks if user inputs A
        { 
            transform.Translate(Vector3.forward * Time.deltaTime * left_right_speed); //moving charcater left

        }
        if (Input.GetKey(KeyCode.D))  //checks if user inputs D
        {
            transform.Translate(Vector3.back * Time.deltaTime * left_right_speed); //moving charcater right
        }


        _score.text = score.ToString("00");
        _target.text = target.ToString("00");


        if (score == target) //checks if the score is equal to target
        {
            score = target;
            WinText.SetActive(true); //then sets the win text on
            //spawner.SetActive(false);
            //spawner.GetComponent<Spawner>().enabled = false;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item") //CHECKS IF THE BALL INTERACTS WITH THE CUBE THEN INCREMENTS THE SCORE BY 1
        {
            score += 1;
        }
    }
}
