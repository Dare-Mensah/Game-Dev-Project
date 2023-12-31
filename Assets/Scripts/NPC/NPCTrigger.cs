using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public GameObject dialogueBox; //dialoguebox
    public Animator animator;
    public Animator npcAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(true); //shows dialogue box
            animator.SetBool("isTalking", true);
            npcAnimator.SetBool("isTalking", true);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(false);//disables dialogue box
            animator.SetBool("isTalking", false);
            npcAnimator.SetBool("isTalking", false);
        }
    }
}
