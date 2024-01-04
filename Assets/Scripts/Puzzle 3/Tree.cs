using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully
using UnityEngine.SceneManagement;  // Add this to access the SceneManager.

public class Tree : MonoBehaviour
{ // the tree class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    public Color hitColor;      // The color to set when hit.
    public MeshRenderer mr;     // A reference to the MeshRenderer component.
    public GameObject player;   // Public reference to the player object.
    private Vector3 originalSpawnPoint; // Store the original spawn point.

    void Start() //method intialisation
    {
        // Initialize the original spawn point.
        originalSpawnPoint = player.transform.position;
    }

    // Called when another object collides with us.
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player object.
        if (collision.gameObject == player) //if statement used as a conditional check to evaluate whether proceeding code should execute 
        {
            // Set our color to "hitColor."
            mr.material.color = hitColor; //the hitcolor is set via the use of intialisation

            // Reset the player to the original spawn point.
            ResetPlayerPosition();
        }
    }

    // Reset the player to the original spawn point.
    void ResetPlayerPosition()
    {
        player.transform.position = originalSpawnPoint; //initialisation ensurres that the player transform position is equated to the original spawn point for the player
    }
}
