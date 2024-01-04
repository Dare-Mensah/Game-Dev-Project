using System.Collections;
using System.Collections.Generic;
using UnityEngine; //importing unityengine that enables for unity specific functions/features to be made use of
using TMPro; //importing tmpro
using UnityEngine.UI;//unity engine UI imported to allow for qualitative features to be deployed effectively

public class Timer : MonoBehaviour
{ // timer class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    //displays the current time.
    [SerializeField] TextMeshProUGUI timerText;
    //tracking the ongoing time.
    public float currentTime;
    // setting the initial time value
    public float startingTime;
    //text shows you winning or not
    public GameObject WinText;

    //player and its related camera
    public GameObject player;

    public GameObject playerCam;

    public GameObject puzzleCam;
    //shows when time runs out


    public GameObject TimesUp;
    // trigger character interactions or events
    public GameObject CharacterTrigger;
    //object represent start of a puzzle
    public GameObject puzzleStart;
    //game environment
    public GameObject nextPlatform;

    public GameObject altPlatform;

    //public GameObject ball;

    //different NPCs in the game
    public GameObject currNPC;

    public GameObject nextNPC;

    public GameObject altNPC;

    //UI 
    public GameObject BuySlot;

    public GameObject Ball;

   
    //to check if it is running.
    public bool notRunning;
    //a position in the Unity game space
    Vector3 originalPos;

    //win sound
    public AudioSource winSound;

    //lose sound
    public AudioSource loseSound;

    private bool hasWon = false;
    private bool hasLost = false;


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
            //Ball.SetActive(true);
        }
        //currentTime -= 1 * Time.deltaTime;
        //int minutes = Mathf.FloorToInt(currentTime / 60);
        //int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = currentTime.ToString("00:00");

        //if (Input.GetKey(KeyCode.Escape)) //leave before time runs out or before the player wins
        //{
            //currentTime = startingTime;
            //playerCam.SetActive(true);
            //puzzleCam.SetActive(false);
            //player.SetActive(true);

        //}


        //if(puzzleCam.activeInHierarchy == true)
        //{
            //Ball.SetActive(true);
        //}

        if(currentTime > 1 && WinText.activeInHierarchy == true) // if the player wins
        { //SETS THE PLAYER TO TRUE SETS THE NEXT PLATOFRM TO ACTIVE AND SETS THE (WIN) NPC  TO TRUE
            //winSound.Play();
            player.SetActive(true);
            TimesUp.SetActive(false);
            StartCoroutine(WaitBeforeChange());
            CharacterTrigger.SetActive(false);
            nextPlatform.SetActive(true);
            puzzleStart.SetActive(false);
            currNPC.SetActive(false);
            nextNPC.SetActive(true);

            PlayWinSound();

        }

        if (currentTime <=1 && WinText.activeInHierarchy == false) // if the player loses
        {//SETS THE PLAYER TO TRUE SETS THE NEXT PLATOFRM TO ACTIVE AND SETS THE (LOSE) NPC  TO TRUE
            //loseSound.Play();
            TimesUp.SetActive(true);
            StartCoroutine(WaitBeforeChange());
            player.SetActive(true);
            CharacterTrigger.SetActive(false);
            altNPC.SetActive(true);
            currNPC.SetActive(false);
            puzzleStart.SetActive(false);
            altPlatform.SetActive(true);
            BuySlot.SetActive(true);

            PlayLoseSound();
        }


    }



    IEnumerator WaitBeforeChange()
    {
        //wait for 3 seconds
        yield return new WaitForSeconds(3);
        //close camera
        puzzleCam.SetActive(false);
    }


    private void PlayWinSound()
    {
        // Play the win sound only if it hasn't been played yet
        if (!hasWon)
        {
            winSound.Play();
            hasWon = true;
        }

        // Optionally, add any additional logic or actions related to winning
    }

    private void PlayLoseSound()
    {
        // Play the lose sound only if it hasn't been played yet
        if (!hasLost)
        {
            loseSound.Play();
            hasLost = true;
        }

        // Optionally, add any additional logic or actions related to losing
    }


}
