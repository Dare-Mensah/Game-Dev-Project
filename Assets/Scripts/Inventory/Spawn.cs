using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public string itemName;
    public GameObject itemPrefab;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        // Adjust the z-coordinate to place the item in front of the player
        float distanceInFront = 2f; // You can adjust this value based on your scene
        Vector3 playerposition = player.position + player.forward * distanceInFront;

        Instantiate(itemPrefab, playerposition, Quaternion.identity);
    }
}
