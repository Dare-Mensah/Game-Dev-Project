using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCdialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public AudioSource dialogueSound;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) //the user presses E to go to the next line
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());//start to type the line
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray()) //looping through each charcater and showing text
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            dialogueSound.Play();
        }
    }

    void NextLine() //going to the next line of text
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false); //ones the dialogue is finished it cloeses the dialogue box
        }
    }
}
