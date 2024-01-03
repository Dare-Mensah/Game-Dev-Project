using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unityengine to allow for unity based work to be conducted

public class Spawn : MonoBehaviour
{// spawn class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    public string itemName; //public variable is used as means to store the item name
    public GameObject itemPrefab; //the public game object is used to reference the prefab of the item that is due to be spawned
    private Transform player; //private variable stores the players transform
    public int itemPrice; //public variable stores price of item
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //finds the gameobject that is tagged as "player" and acquires its transform component to allow for assignment to the player variable
    }

    public void SpawnDroppedItem()
    { //a public method is used to handle a dropped item being spawned
        // Adjust the z-coordinate to place the item in front of the player
        float distanceInFront = 2f; // You can adjust this value based on your scene
        Vector3 playerposition = player.position + player.forward * distanceInFront; //the position in front of the player is calculated by utilising the players forward direction and distance

        Instantiate(itemPrefab, playerposition, Quaternion.identity); //the itemprefab is instantiated via the use of the Instantiate () method
    }
}
