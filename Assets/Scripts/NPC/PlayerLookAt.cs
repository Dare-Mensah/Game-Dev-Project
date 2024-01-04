using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this line

public class PlayerLookAt : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Ensure TextMesh Pro is imported
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform); // transforms the npc position based on the player position
    }
}

