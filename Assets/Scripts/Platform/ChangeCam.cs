using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public GameObject triggerCam;

    public AudioSource bridgeSound;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") //if the player enters the trigger then the trigger cam is set to active
        {
            triggerCam.SetActive(true);
            bridgeSound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the player enters the trigger then the trigger cam is set to false
        {
            triggerCam.SetActive(false); 

        }
    }
}
