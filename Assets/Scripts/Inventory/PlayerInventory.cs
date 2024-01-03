using System.Collections;// use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine;//importing unityengine to allow for unity based work to be conducted
using TMPro;

public class PlayerInventory : MonoBehaviour
{ //declaring the playerinventory class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    public int Gold; //the use of a public variable helps to keep a track and record of the players gold quantity
    public TextMeshProUGUI GoldAmountText; //public variable is used to thus display this quantity of gold the player has within the UI
    // Start is called before the first frame update
    void Start()
    {
        //nothing happens in this instance as the empty start method is used for intialisation
    }

    // Update is called once per frame
    void Update()
    {
        GoldAmountText.text = Gold + " Gold"; //this helps to ensure that the User interface features/elements are updated to reflect current gold quantites
    }
}
