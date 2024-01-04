using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine so that unity based features can be deployed
using TMPro; //importing TMpro
using UnityEngine.UI;//importing unity UI so that qualitative features can be appended to aid user experience

public class PuzzleComplete : MonoBehaviour
{ //the class puzzle complete inherits from the monobehaviour class which enables it to be assigned to the game object
    public GameObject WinText; //public reference to the game obj responsible for displaying win text when player successfully attemps game
    public bool Win = false; //win set to false through initialisation

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball") //CHECKS IF BALL ENTERS TRIGGER
        {
            WinText.SetActive(true); //SETS THE WIN TEXT TO TRUE
            Win = true; //the initialisation prevalent here shows the win to be activated to a true state


        }
    }
}
