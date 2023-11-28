using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CollectItem : MonoBehaviour
{
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
        score = 0;
        spawner.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        _score.text = score.ToString("00");
        _target.text = target.ToString("00");

        if(score == target)
        {
            score = target;
            WinText.SetActive(true);
            //spawner.SetActive(false);
            //spawner.GetComponent<Spawner>().enabled = false;

        }
        
        if(puzzleCam.activeInHierarchy == true) //CHECKS IF THE PUZZLE CAM IS ACTIVE THEN SETS THE SPAWNER TO TRUE
        {
            spawner.SetActive(true);
        }

        //if(Input.GetKey(KeyCode.Escape))
        //{
            //score = 0;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item") //CHECKS IF THE BALL INTERACTS WITH THE CUBE THEN INCREMENTS THE SCORE BY 1
        {
            score += 1;
        }
    }
}



