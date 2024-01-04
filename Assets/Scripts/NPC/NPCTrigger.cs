using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unityengine to allow for unity based work to be conducted
using TMPro; // importing tmpro

public class NPCTrigger : MonoBehaviour
{ // npctrigger class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features
    public TextMeshProUGUI textComponent; 
    public GameObject dialogueBox; //public game object references the dialogue box that is present within NPC conversation

    public Animator animator; //public animator references controlling animations for player or object
    public Animator npcAnimator; //public animator reference for the animations prevalent on npc
    private void OnTriggerEnter(Collider other)
    { //checks to see if the collider is tagged as "player"
        if(other.gameObject.tag == "Player")
        { 
            dialogueBox.SetActive(true); //the dialogue box is activated to thus make it visibly known to the player
            animator.SetBool("isTalking", true);//sets the isTalking boolean to a true state that starts the talk animation of player
            npcAnimator.SetBool("isTalking", true);//sets the isTalking boolean to a true state that starts the talk animation of npc


        }
    }

    private void OnTriggerExit(Collider other)
    { // class called when another collider exits the trigger collider assigned to the GameObject
        if (other.gameObject.tag == "Player")
        {//check to see if the collider that exited is tagged as "Player"
            dialogueBox.SetActive(false);//the dialogue box is deactivated thus its invisible when the player exits the trigger
            animator.SetBool("isTalking", false); //sets the isTalking boolean to a false state that stops the talk animation of player
            npcAnimator.SetBool("isTalking", false);//sets the isTalking boolean to a false state that stops the talk animation of npc
        }
    }
}
