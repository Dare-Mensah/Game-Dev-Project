using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Add this to access the SceneManager.

public class Tree : MonoBehaviour
{
    public Color hitColor;      // The color to set when hit.
    public MeshRenderer mr;     // A reference to the MeshRenderer component.
    public GameObject player;   // Reference to the player object.
    private Vector3 originalSpawnPoint; // Store the original spawn point.

    void Start()
    {
        // Initialize the original spawn point.
        originalSpawnPoint = player.transform.position;
    }

    // Called when another object collides with us.
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player object.
        if (collision.gameObject == player)
        {
            // Set our color to "hitColor."
            mr.material.color = hitColor;

            // Reset the player to the original spawn point.
            ResetPlayerPosition();
        }
    }

    // Reset the player to the original spawn point.
    void ResetPlayerPosition()
    {
        player.transform.position = originalSpawnPoint;
    }
}
