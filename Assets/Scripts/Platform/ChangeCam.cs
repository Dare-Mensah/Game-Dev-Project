using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unityengine to allow for unity based work to be conducted

public class ChangeCam : MonoBehaviour
{ // playerlookat class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features
    public GameObject triggerCam; //public gameobject that reference to the camera

    public AudioSource bridgeSound; //public audiosource is a reference to sound that will be played when camera pans


    private void OnTriggerEnter(Collider other)
    { //check to see if collider that is entered is tagged as "player"
        if(other.gameObject.tag == "Player") //if the player enters the trigger then the trigger cam is set to active
        {
            triggerCam.SetActive(true); //this activates the trigger camera that changes player viewpoint
            bridgeSound.Play(); //this plays bridgesound resultant of camera change
        }
    }

    private void OnTriggerExit(Collider other)
    { // check to see if the collider that exited is tagged as "player"
        if (other.gameObject.tag == "Player") //if the player enters the trigger then the trigger cam is set to false
        {
            triggerCam.SetActive(false);  //the trigger camera is deactivated reverting to default camera setting

        }
    }
}
