using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PuzzleComplete : MonoBehaviour
{ //TO BE CHNAGED 
    public GameObject WinText;
    public bool Win = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball") //CHECKS IF BALL ENTERS TRIGGER
        {
            WinText.SetActive(true); //SETS THE WIN TEXT TO TRUE
            Win = true;


        }
    }
}
