using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialPrompts : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.E))
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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
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
        if(index < lines.Length - 1)
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
        if(other.gameObject.tag == "Player")
        {
            npcCam.SetActive(true);
            dialogueBox.SetActive(true);
            textComponent.text = string.Empty;
            StartDialogue();
            StartCoroutine(WaitForChange());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            npcCam.SetActive(false);
            dialogueBox.SetActive(false);
            textComponent.text = string.Empty;
            StopAllCoroutines();
        }
    }






}
