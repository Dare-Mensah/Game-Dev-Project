using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CollectItem : MonoBehaviour
{
    //track player score
    public int score;
    public int target;

    [SerializeField] TextMeshProUGUI _score;
    [SerializeField] TextMeshProUGUI _target;

    public GameObject WinText;
    public GameObject spawner;
    public GameObject puzzleCam;
    public GameObject platform;
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



