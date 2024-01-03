using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{ // pausemenu class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    public GameObject pauseMenu;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false); //this renders the pause menu to be intially inactive so that it doesnt display when the game is first started

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // if the user presses the escape key
        {

            if (isPaused) //checks if paused
            {
                ResumeGame(); //resumes the game
            }
            else
            {
                PauseGame(); //pauses the game
            }
        }
    }


    public void PauseGame()
    { //public method is used here as a means to pause the game
        pauseMenu.SetActive(true); //this will activate the pause menu UI
        Time.timeScale = 0f; //this sets the time scale to 0 to thus effectively pause all time dependent actions taken within the game
        isPaused = true; // the ispaused flag is set to true
        Cursor.lockState = CursorLockMode.None; //this ensures that the cursor is unlocked while making it visible to thus allow the player to interact with the pause menu
        Cursor.visible = true; //shows the cursor and unlocks it
    }

    public void ResumeGame()
    { //this public method will help to resume the game at its current state
        pauseMenu.SetActive(false); //this will deactivate the pause menu UI
        Time.timeScale = 1f; //the time scale is resultantly reset to 1 thereby allowing for normal gameplay to re-commence
        isPaused = false; //thus sets the isPaused flag tofalse

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    public void GoToMainMenu()
    { //this public method allows for the ability to navigate to the main menu page
        Time.timeScale = 1f; //the time scale is reset to 1 to therefore ensure the main menu works as intended
        SceneManager.LoadScene("StartScreen"); //this allows for the starting screen scene to be successfully loaded
    }

    public void QuitGame()
    { //this method allows for the ability to quit the game
        Application.Quit();// the quit function enables for the appliction to be quit
    }
}
