using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterCharacterTrigger : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool nextLineComplete;
    private int index;

    public GameObject npcTrigger;
    public GameObject puzzlCam;
    public GameObject npcCam;
    public GameObject Player;

    public GameObject playergreet;
    public GameObject playerYes;
    public GameObject playerNo;




    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))//yes
        {
            if (textComponent.text == lines[index])
            {
                NextLine();

                if (nextLineComplete == true)
                {
                    npcCam.SetActive(false);
                    textComponent.text = string.Empty;
                    puzzlCam.SetActive(true);
                    StartCoroutine(WaitForCam());
                    StartCoroutine(WaitForCharaacter());
                    playerYes.SetActive(true);
                    playergreet.SetActive(false);
                    //npcTrigger.SetActive(false);
                }
            }

        }

        if (Input.GetKey(KeyCode.F)) //no
        {
            npcCam.SetActive(false);
            textComponent.text = string.Empty;
            playerNo.SetActive(true);
            playergreet.SetActive(false);

        }



        //if (Enter == true)
        //{
            //PressEText3.SetActive(true);
            //StartText1.SetActive(true);
        //}

        //if (Enter && MidText2.activeInHierarchy == true &&YesText.activeInHierarchy == true )
        //{
           // PressEText3.SetActive(false);
            //StartText1.SetActive(false);
        //}
    }

    IEnumerator WaitForCharaacter()
    {
        yield return new WaitForSeconds(3);

       Player.SetActive(false);
    }


    IEnumerator WaitForCam()
    {
        yield return new WaitForSeconds(2);

        puzzlCam.SetActive(true);
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
        if (other.gameObject.tag == "Player")
        {
            npcCam.SetActive(true);
            textComponent.text = string.Empty;
            StartDialogue();
            playergreet.SetActive(true);
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

    void NextLine()
    {
        if (index < lines.Length - 1)
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
