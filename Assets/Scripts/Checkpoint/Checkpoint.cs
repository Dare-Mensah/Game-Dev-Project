using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{ /
    public List<Transform> checkpoints = new List<Transform>(); // List of checkpoint Transforms.
    private Transform lastCheckpoint; // Stores the last checkpoint closest to the player.
    public GameObject player; // a public reference is instantiated to ensure for reference to the GameObject of the player

    private void OnTriggerEnter(Collider other)//this method is a unity specific one that is called when a collider enters into the trigger collider
    {
        if (other.CompareTag("Player"))
        { //Checks if the player has enetred the collder and respawns them at the clostse checkpoint
            lastCheckpoint = GetClosestCheckpoint(other.transform);//ascertains what is the closest checkpoint at the point of player collision
            RespawnPlayer(other.transform); //the player is respawned at the point of the last checkpoint
        }
    }

    void RespawnPlayer(Transform playerTransform) //this method resets the players position to the point of the last checkpoint
    {
        if (lastCheckpoint != null) //if statement checks to see if there is a last checkpoint 
        {
            player.transform.position = lastCheckpoint.position;
            //  Logic to reset player transform poistion to the closest checkpoint.
        }
    }

    Transform GetClosestCheckpoint(Transform playerTransform)
    { //the method is used as a means to ascertain the checkpoint that is closest to the player location
        Transform closestCheckpoint = null; //closestcheckpoint value stored
        float closestDistance = Mathf.Infinity; //the the distance of the closest checkpoint is compared to infinity

        foreach (Transform checkpoint in checkpoints)
        { //this will help to iterative search through each checkpoint in the list
            float distance = Vector3.Distance(player.transform.position, checkpoint.position);
            if (distance < closestDistance) //Checks if the disatance is less than the closets distnce
            {
                closestCheckpoint = checkpoint;//updating the closest checkpoint
                closestDistance = distance;//updating the closest checkpoint distance
            }
        }

        return closestCheckpoint; //return statement returns the closest checkpoint that is found
    }
}
