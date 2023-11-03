using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialPrompts : MonoBehaviour
{

    public GameObject npcCam;


    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool nextLineComplete;
    private int index;


    public GameObject playergreet;
    public GameObject playerYes;
    public GameObject playerNo;
    //public GameObject npcTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.E))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();

                playergreet.SetActive(false);
                playerYes.SetActive(true);


                if (nextLineComplete == true)
                {
                    npcCam.SetActive(false);
                    textComponent.text = string.Empty;
                    //npcTrigger.SetActive(false);
                }
            }
            //else
            //{
                //StopAllCoroutines();
                //textComponent.text = lines[index];
            //}
        }

        if (Input.GetKey(KeyCode.F))
        {
            npcCam.SetActive(false);
            textComponent.text = string.Empty;
            playergreet.SetActive(false);
            playerNo.SetActive(true);
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            npcCam.SetActive(false);
            textComponent.text = string.Empty;
            playergreet.SetActive(false);
            playerYes.SetActive(false);
            playerNo.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            npcCam.SetActive(true);
            textComponent.text = string.Empty;
            StartDialogue();
            playergreet.SetActive(true);

        }

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            nextLineComplete = true;

        }
        else
        {
            gameObject.SetActive(false);
        }
    }




}
