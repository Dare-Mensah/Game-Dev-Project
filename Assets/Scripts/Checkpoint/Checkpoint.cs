using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public List<Transform> checkpoints = new List<Transform>(); // List of checkpoint Transforms.
    private Transform lastCheckpoint; // Stores the last checkpoint closest to the player.
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { //Checks if the player has enetred the collder and respawns them at the clostse checkpoint
            lastCheckpoint = GetClosestCheckpoint(other.transform);
            RespawnPlayer(other.transform);
        }
    }

    void RespawnPlayer(Transform playerTransform)
    {
        if (lastCheckpoint != null)
        {
            player.transform.position = lastCheckpoint.position;
            //  Logic to reset player transform poistion to the closest checkpoint.
        }
    }

    Transform GetClosestCheckpoint(Transform playerTransform)
    {
        Transform closestCheckpoint = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform checkpoint in checkpoints)
        {
            float distance = Vector3.Distance(player.transform.position, checkpoint.position);
            if (distance < closestDistance) //Checks if the disatance is less than the closets distnce
            {
                closestCheckpoint = checkpoint;
                closestDistance = distance;
            }
        }

        return closestCheckpoint;
    }
}
