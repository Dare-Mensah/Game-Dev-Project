using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions; //list of resolutions

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume); //changing the volume settings
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); //chaning the graphic settings
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen; //toggoling fullscreen 
    }

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions(); //clear out all options in resolution drop down

        List<string> options = new List<string>(); //converting the list of options to strings 

        for (int i = 0; i < resolutions.Length; i++) //looping through all the resolutions 
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
    }



}
