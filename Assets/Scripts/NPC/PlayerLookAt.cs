using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{// playerlookat class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features
    public TextMeshProUGUI textComponent; 
    // Start is called before the first frame update
    public Transform Player;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform); // transforms the npc positon based on the player position
    }


}

