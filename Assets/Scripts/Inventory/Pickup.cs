using System.Collections;// use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic; 
using UnityEngine; //importing unityengine to allow for unity based work to be conducted

public class Pickup : MonoBehaviour
{ //publci class pickup is one that inherits from the monobehaviour class enabling for it to be assigned to the gameobjects

    private InventoryController inventory; //this private variable is utilised to hold a reference to the inventory controller script
    public GameObject itemButton;//this public variable is used to indicate a button to be deployed within the UI of the inventory systems
    public string itemName;// this publci variable helps to store the name of the items
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<InventoryController>(); //the inventory controller is found in scene and assigned to inventory variable accordingly
    }

    private void OnTriggerEnter(Collider other)
    { //unity specific method that is called at the point at which another collider enters within the trigger collider that is found to be assigned to the game object
        if(other.CompareTag("Player"))
        { //condition statement check to see if the collider is listed as "player"
            for(int i = 0; i < inventory.slots.Length; i++)
            { //use of for loop iterates through each slot of the inventory
                if (inventory.isFull[i] == true && inventory.slots[i].transform.GetComponent<Slots>().amount < 2) //stack amount
                {//check to see the current invetory slot is filled up and whether item quanitity is below that of the available inventory space
                    if (itemName == inventory.slots[i].transform.GetComponentInChildren<Spawn>().itemName) //chejkcing if the item we want to pick up is the same then stack
                    {//if statement is a condition based check to ensure for adequate item selection process
                        Destroy(gameObject); //destroy method is used to eliminate the pickup gameobject from the scene in question
                        inventory.slots[i].GetComponent<Slots>().amount += 1; //increasing the amount of items assigned to the inventory slots
                        break; //break is used to break out of loop 

                    }
                }
                else if(inventory.isFull[i] == false)
                { //a conditional check to see if the current inventory slot is / is not full
                    inventory.isFull[i] = true; // the inventory slot is signalled as being full
                    Instantiate(itemButton, inventory.slots[i].transform.transform, false); //instantiation of the itembutton gameobject within the inventory slot
                    inventory.slots[i].GetComponent<Slots>().amount += 1; //increasing the item amount assigned to each slot
                    Destroy(gameObject); //the destroy method destroys the pickup gameobject from the scene
                    break; //break function used to break out of the loop after the item pickup process has concluded
                }
            }
        }
    }
}
