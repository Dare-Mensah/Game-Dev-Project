using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    public float currentTime;

    public float startingTime;

    public GameObject WinText;


    public GameObject player;
    public GameObject playerCam;
    public GameObject puzzleCam;
    public GameObject TimesUp;
    public GameObject CharacterTrigger;


    public GameObject platform;

    public GameObject playerGreeting;
    public GameObject playerYes;
    public GameObject playerNo;


    public bool notRunning;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime >1 && puzzleCam.activeInHierarchy == true && !notRunning)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        //currentTime -= 1 * Time.deltaTime;
        //int minutes = Mathf.FloorToInt(currentTime / 60);
        //int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = currentTime.ToString("00:00");

        if (Input.GetKey(KeyCode.Escape)) //leave before time runs out or before the player wins
        {
            currentTime = startingTime;
            playerCam.SetActive(true);
            puzzleCam.SetActive(false);
            player.SetActive(true);
            playerYes.SetActive(false);

        }

        if(currentTime > 1 && WinText.activeInHierarchy == true) // if the player wins
        {
            player.SetActive(true);
            StartCoroutine(WaitBeforeChange());
            CharacterTrigger.SetActive(false);
            platform.SetActive(true);
            playerYes.SetActive(false);

        }

        if (currentTime <=1 && WinText.activeInHierarchy == false) // if the player loses
        {
            TimesUp.SetActive(true);
            StartCoroutine(WaitBeforeChange());
            player.SetActive(true);
            CharacterTrigger.SetActive(false);
            playerYes.SetActive(false);

        }


    }



    IEnumerator WaitBeforeChange()
    {
        yield return new WaitForSeconds(3);

        puzzleCam.SetActive(false);
    }

}
