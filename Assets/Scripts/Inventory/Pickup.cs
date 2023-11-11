using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item = new Item("Item Name", 1);

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) // IF THE PLAYER PICKS UP AND OBJECT
        {
            Inventory.instance.AddItem(item); //WE ADD ITEM 
            Destroy(gameObject); //DESTROY THE OBJECT
        }
    }
}
