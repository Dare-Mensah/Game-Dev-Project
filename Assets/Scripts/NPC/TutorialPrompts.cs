using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialPrompts : MonoBehaviour //SCRIPT USED TO BE USED FOR ONLY TUTORIAL NPC BUT IS NOW USED FOR ALL
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    public GameObject next;
    public GameObject escape;
    public GameObject npcCam;
    public GameObject dialogueBox;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) //checks if the user has inputted E then it goes to the next line of text
        {
            if (textComponent.text == lines[index])
            {
                NextLine(); 
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        if(Input.GetKeyDown(KeyCode.X)) //If the user pressed X the then the dialogue box closes
        {
            //npcCam.SetActive(false);
            dialogueBox.SetActive(false);
            textComponent.text = string.Empty;
            StopAllCoroutines();
        }

    }

    void StartDialogue()
    {
        index = 0;
        textComponent.text = string.Empty; // Clear text before starting a new dialogue
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty; // Clear text before typing a new line
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    IEnumerator WaitForChange()
    {

        next.SetActive(true);
        escape.SetActive(true);
        yield return new WaitForSeconds(2);
    }


    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StopCoroutine("TypeLine"); // Stop the previous coroutine
            textComponent.text = string.Empty; // Clear the text before starting a new line
            StartCoroutine(TypeLine());
        }
        else
        {
           //gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        { //Check if the user enters the trigger then start dialogue
            //npcCam.SetActive(true);
            dialogueBox.SetActive(true);
            textComponent.text = string.Empty; 
            StartDialogue();
            StartCoroutine(WaitForChange());        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        { //Checks if the user exits the trigger then stops dialogue
            //npcCam.SetActive(false);
            dialogueBox.SetActive(false);
            textComponent.text = string.Empty;
            StopAllCoroutines();

        }
    }






}
