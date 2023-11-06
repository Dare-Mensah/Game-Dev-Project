using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class EnterCharacterTrigger : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    public GameObject puzzlCam;
    public GameObject npcCam;
    public GameObject Player;

    public GameObject next;
    public GameObject escape;
    public GameObject dialogueBox;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //if the player presses E then it goes to the second line
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


        if (Input.GetKeyDown(KeyCode.Escape))
        {//If the player presses the escape button the dialogue closes
            npcCam.SetActive(false);
            dialogueBox.SetActive(false);
            textComponent.text = string.Empty;
            StopAllCoroutines();
        }

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }


    IEnumerator TypeLine()
    {
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
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else
        {
            //gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {//Checks if the player has eneter the trigger then starts the dialogue
            npcCam.SetActive(true);
            dialogueBox.SetActive(true);
            textComponent.text = string.Empty;
            StartDialogue();
            StartCoroutine(WaitForChange());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {//Checks if the player has exited the trigger then stops the dialogue
            npcCam.SetActive(false);
            dialogueBox.SetActive(false);
            textComponent.text = string.Empty;
            StopAllCoroutines();
        }
    }



}
