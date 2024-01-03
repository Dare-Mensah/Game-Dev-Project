using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unityengine to allow for unity based work to be conducted
using TMPro;

public class NPCdialogue : MonoBehaviour
{// npcdialogue class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features
    public TextMeshProUGUI textComponent;
    public string[] lines; //public array of strings are used here to contain the various lines of dialogue
    public float textSpeed; //public variable controls speed of which text will appear during conversation

    public AudioSource dialogueSound; //public AudioScore is used to play sound during interaction with characters

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty; //the textcomponent is initialised with an empty string
        StartDialogue();// calls the startdialogue method in order for npc dialogue to commence
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) //the user presses E to go to the next line
        {
            if(textComponent.text == lines[index])
            { //a check to see if the line of dialogue text has been effectively displayed
                NextLine(); //calls nextLine to therefore proceed to next line of dialogue
            }
            else
            {
                StopAllCoroutines(); // stops all corountines if the player presses the key E before a dialogue line is finished displaying
                textComponent.text = lines[index]; // displays immediate next line of text
            }
        }
    }

    void StartDialogue()
    {
        index = 0; //the dialogue index is set to 0 in order to start from the first line in sequence
        StartCoroutine(TypeLine());//start to type the line
    }

    IEnumerator TypeLine()
    { //loops through each charater within the currently delivered line of dialogue text
        foreach(char c in lines[index].ToCharArray()) //looping through each charcater and showing text
        {
            textComponent.text += c; //adds the character to the variable text building dialogiue character by character
            yield return new WaitForSeconds(textSpeed); //this ensures system waits momentarily as set by text speed before the next character can be added
            dialogueSound.Play(); //the dialogue sound is played as a result of each interaction with characters
        }
    }

    void NextLine() //going to the next line of text
    {
        if(index < lines.Length - 1)
        { //this is a check to see if there are additional lines of dialogue to present
            index++; //increases the dialogue index to proceed to next line
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false); //once all dialogue has been displayed the game object is set to deactivate
        }
    }
}
