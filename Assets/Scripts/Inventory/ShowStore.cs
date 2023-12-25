using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStore : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject StoreUI;
    public GameObject npcDialogue;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //checks if the user enter the trigger event
        {
            StoreUI.SetActive(true); //if so the store is set to active and the npc dialoguie is set to false
            npcDialogue.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StoreUI.SetActive(false);
        }
    }
}
