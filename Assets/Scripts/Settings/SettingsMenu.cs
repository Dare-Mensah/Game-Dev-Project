using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{   // the settingsmenu class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features


    public AudioMixer audioMixer; //public reference to the audio mixer variable

    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions; //list of resolutions is define via the use of the resolution [] list as shown in code

    public void SetVolume(float volume)
    { //public method is defined and called to enable for player to change the volume in the game which boosts the accessibility of game
        audioMixer.SetFloat("Volume", volume); //changing the volume settings via the use of setFloat which adjusts float values assigned to volume
    }

    public void SetQuality (int qualityIndex)
    {//public method is defined and called to enable for players to change graphic quality which helps visually impaired players
        QualitySettings.SetQualityLevel(qualityIndex); //graphic quality is changed via the use of setQualityLevel function that changes graphics
    }

    public void SetFullScreen (bool isFullScreen)
    { //public method is defined and called to enable for fullscreen to be navigated
        Screen.fullScreen = isFullScreen; //toggoling fullscreen 
    }

    void Start()
    { //start method is called and defined 
        resolutions = Screen.resolutions; //new resolution is assigned to the value of the current resolution so that player changes are reflected in real time

        resolutionDropdown.ClearOptions(); //clear out all options in resolution drop down via the use of the clearoptions() method as shown here

        List<string> options = new List<string>(); //converting the list of options to strings 

        for (int i = 0; i < resolutions.Length; i++) //for loop used in looping through all the resolution variations 
        {
            string option = resolutions[i].width + "x" + resolutions[i].height; //this allows for a string variable called option to store the different variations of resolutions made accessible to players in the settings
            options.Add(option);//the option tool is then appended to the options list via the use of the Add() method as shown in the code
        }

        resolutionDropdown.AddOptions(options); //calling the addoptions() method upon the resolutiondropdown object that allows for all resolutions options to be formatted and appended to the UI for the user to select
    }



}
