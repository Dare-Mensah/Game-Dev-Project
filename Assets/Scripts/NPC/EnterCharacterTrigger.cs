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
    public bool nextLineComplete;
    private int index;

    public GameObject puzzlCam;
    public GameObject npcCam;
    public GameObject Player;

    public GameObject next;
    public GameObject escape;
    public GameObject options;
    public GameObject dialogueBox;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                npcCam.SetActive(false);
                dialogueBox.SetActive(false);
                textComponent.text = string.Empty;
                StopAllCoroutines();
            }

            if (index == lines.Length - 1)
            {
                StartCoroutine(WaitForOptions());
            }
        }

        if (Input.GetKeyDown(KeyCode.O) && index == lines.Length - 1)
        {
            npcCam.SetActive(false);
            dialogueBox.SetActive(false);
            textComponent.text = string.Empty;
            options.SetActive(false);
            puzzlCam.SetActive(true);
            //StartCoroutine(WaitForCharaacter());

        }
        if (Input.GetKeyDown(KeyCode.P) && index == lines.Length - 1)
        {
            npcCam.SetActive(false);
            dialogueBox.SetActive(false);
            textComponent.text = string.Empty;
            options.SetActive(false);
            StopAllCoroutines();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            npcCam.SetActive(false);
            dialogueBox.SetActive(false);
            textComponent.text = string.Empty;
            options.SetActive(false);
            StopAllCoroutines();
        }

    }

    IEnumerator WaitForCharaacter()
    {
        yield return new WaitForSeconds(3);

       Player.SetActive(false);
    }




    IEnumerator WaitForOptions()
    {
        yield return new WaitForSeconds(1);

        options.SetActive(true);
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            npcCam.SetActive(false);
            dialogueBox.SetActive(false);
            textComponent.text = string.Empty;
            options.SetActive(false);
            StopAllCoroutines();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            npcCam.SetActive(true);
            dialogueBox.SetActive(true);
            textComponent.text = string.Empty;
            StartDialogue();
            StartCoroutine(WaitForChange());
        }

    }



}
