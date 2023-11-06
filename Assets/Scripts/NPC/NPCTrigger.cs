using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class NPCTrigger : MonoBehaviour //SCRIPT IS CURRENTLY NOT IN  USE WILL BE DELETED IN FUTURE ITERATIONS
{

    public GameObject greetingText;
    public GameObject objectiveText;
    public GameObject pressEText;

    public GameObject yesText;
    public GameObject noText;

    public GameObject puzzleCam;
    public GameObject player;
    


    public bool startConvo;
    public bool startPuzzle;
    // Start is called before the first frame update
    void Start()
    {
        startConvo = false;
        startPuzzle = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (startConvo == true && Input.GetKey(KeyCode.E))
        {
            greetingText.SetActive(false);
            pressEText.SetActive(false);
            objectiveText.SetActive(true);

            yesText.SetActive(true);
            noText.SetActive(true);
        }

        if (startConvo == true && Input.GetKey(KeyCode.F))
        {
            objectiveText.SetActive(false);

            yesText.SetActive(false);
            noText.SetActive(false);

            puzzleCam.SetActive(true);
            startPuzzle = true;
        }

        if (startConvo == true && Input.GetKey(KeyCode.G))
        {
            greetingText.SetActive(true);
            pressEText.SetActive(true);

            objectiveText.SetActive(false);
            yesText.SetActive(false);
            noText.SetActive(false);
        }

        if (startPuzzle == true)
        {
            StartCoroutine(WaitBeforeChange());
        }





    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            startConvo = true;
        }
    }

    IEnumerator WaitBeforeChange()
    {
        yield return new WaitForSeconds(2);

        player.SetActive(false);
    }




}
