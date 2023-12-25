using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private InventoryController inventory;
    public GameObject itemButton;
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            for(int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == true && inventory.slots[i].transform.GetComponent<Slots>().amount < 2) //stack amount
                {
                    if (itemName == inventory.slots[i].transform.GetComponentInChildren<Spawn>().itemName) //chejkcing if the item we want to pick up is the same then stack
                    {
                        Destroy(gameObject);
                        inventory.slots[i].GetComponent<Slots>().amount += 1;
                        break;

                    }
                }
                else if(inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform.transform, false);
                    inventory.slots[i].GetComponent<Slots>().amount += 1;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
