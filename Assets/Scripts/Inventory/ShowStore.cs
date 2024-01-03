using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unityengine to allow for unity based work to be conducted

public class ShowStore : MonoBehaviour
{// showstore class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features
    // Start is called before the first frame update
    public GameObject StoreUI;//this public gameobject variable reference the UI for the in game buy station
    public GameObject npcDialogue; //this public variable references the UI for NPC dialogue/conversation


    private void OnTriggerEnter(Collider other)
    { //is a unity specific method that is called when another collider enters the trigger collider that is assigned to that of the gameobject
        if (other.gameObject.tag == "Player") //checks if the user enter the trigger event
        {
            StoreUI.SetActive(true); //if so the store is set to active and the npc dialoguie is set to false
            npcDialogue.SetActive(false);// the NPC dialogue is set to be inactive thus hiding it
        }
    }

    private void OnTriggerExit(Collider other)
    { //is a unity specific method called when colliders exit the trigger one assigned this gameobject
        if(other.gameObject.tag == "Player")
        {  // a check ensues to check whether the collider is tagged as players^^
            StoreUI.SetActive(false); //should the collider be deemed as the player then the in game store UI is set to inactive thus hiding it.
        }
    }
}
