using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unityengine to allow for unity based work to be conducted
using TMPro;

public class Slots : MonoBehaviour
{ // slots class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features
    private InventoryController inventory; //private variabke is used to reference the inventory controller script

    public int i; // the public variable i is used an identifier within the slot

    public TextMeshProUGUI amountText; // the public variable is used for the textmeshprogui component that is deplpyed to display no of items within the slot

    public int amount; //public variable for keeping a track of the no of items within slot

    public TextMeshProUGUI ItemName; //the public variable for the textmeshprogui component that will display the name of item in this slot

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();//this assigns the inventorycontroller that is found within the scene to the inventory variable
    }

    // Update is called once per frame
    void Update()
    {
        amountText.text = amount.ToString(); //changes the text of amountText to the amount value thus converting the integer to the string

        if(amount > 1)
        { //if condition used to check if amount is more than 1
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true; //if evaluated to be true then the textmeshprogui component of the first child is enabled for the gameobject
        }
        else
        { //else condition used to check for false condition whereby the textmeshprogui component of the first child is disabled thus ensuring the item quantity is hidden when it is less than a total of 1
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }



        if(transform.childCount == 2)
        { //if condition statement is used to check if the gameobject has a total of 2 children
            inventory.isFull[i] = false; //if condiiton is true then the "isFull" boolean within the inventory to false which signifies that the slot isnt full
        }
    }

    public void DropItem()
    { //public method is called when the player requests to drop an item from the inventory slot
        if(amount > 1) // if condition checks if the amount is more than 1
        {
            amount -= 1; // if evaluated to be true then the amount is decreased by 1 thus an item has been dropped
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem(); //the spawndroppeditem method is called from the spawn component within the game object that results in an item being dropped in the game
        }
        else
        { //an else condition is used to handle for scenario when amount is not more than 1 which would mean slot is thus empty
            amount -= 1;//amount is reduced by 1 which indicates slot to be empty
            GameObject.Destroy(transform.GetComponentInChildren<Spawn>().gameObject); // destroying the spawn components gameobject from the child which removes item from slot
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem();//the spawndroppeditem method is called from the spawn component within the game object that results in an item being dropped in the game
        }
    }
}
