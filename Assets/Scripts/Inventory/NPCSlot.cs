using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCSlot : MonoBehaviour
{ //the npcslot class inherits from the monobehaviour thus ensuring its attatchment to the gameobject
    private PlayerInventory player; //private variable is utilised and declared to make reference to the playerinventory script
    private InventoryController inventory; //private variable is utilised and declared to make reference to the inventorycontroller script
    public Image itemImage; //public image item is utilised and declared to allow for the image of the item to be held effectively
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemPrice;
    public TextMeshProUGUI itemAmount;

    public GameObject itemToBuy; //a public variable is declared to ensure that the item that is about to be bought is appropriately represented
    public int _itemAmount; 
    public TextMeshProUGUI buyPriceText;//a public variable is declared to be able to textually display the buy price of item

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerInventory>(); //the playerinventory component in the game is found and assigned to the player variable
        inventory = FindObjectOfType<InventoryController>();//the inventorycontroller component in the game is found and assigned to the inventory variable
        itemName.text = itemToBuy.GetComponent<Spawn>().itemName;
        itemImage.sprite = itemToBuy.GetComponent<Image>().sprite;// the itemimages sprite is set to the sprite that is defined within the image component of the itemtobuy 
        buyPriceText.text = itemToBuy.GetComponentInChildren<Spawn>().itemPrice + " Gold"; //price is shown to improve accessibility for the user in understanding cost of in-game items
    }

    // Update is called once per frame
    void Update()
    {
        itemAmount.text = "Amount: " + _itemAmount.ToString(); //showing the amount for the item which further improves the gameplay experience
    }


    public void Buy()
    { //this method is called to thus handle the purchasing process users endure when buying in game items
        for (int i = 0; i < inventory.slots.Length; i++) 
        { //for loop iterates through every slot within the inventory array
            if(inventory.isFull[i] == true && inventory.slots[i].transform.GetComponent<Slots>().amount < 20 && player.Gold >= itemToBuy.GetComponentInChildren<Spawn>().itemPrice && _itemAmount > 0) 
            { //condition based statement that checks to see whether the inventory slot is filled already, the item is less than 20 "pieces" and the buy station has the item in stock
                if (itemName.text == inventory.slots[i].transform.GetComponentInChildren<Spawn>().itemName) //checking if the item in the shop has the same name as that in the inventory
                {
                    _itemAmount -= 1; //removing from shop
                    inventory.slots[i].GetComponent<Slots>().amount += 1; //adding to inventory
                    player.Gold -= itemToBuy.GetComponentInChildren<Spawn>().itemPrice; //deducting the gold
                    break;
                }
            }

            else if(inventory.isFull[i] == false && player.Gold >= itemToBuy.GetComponentInChildren<Spawn>().itemPrice && _itemAmount > 0)
            { //condition statement that checks to see if the inventory slots is free and wehter the player has the required currency amount as well as whether store has item in stock
                _itemAmount -= 1; //item quanity is reduced per the no of items purchased by user
                player.Gold -= itemToBuy.GetComponentInChildren<Spawn>().itemPrice;//subtract the item price from the total currency of the player
                inventory.slots[i].GetComponent<Slots>().ItemName.text = itemName.text;
                inventory.isFull[i] = true; //signifying condition whereby the inventory slot is full completely
                Instantiate(itemToBuy, inventory.slots[i].transform, false);
                inventory.slots[i].GetComponent<Slots>().amount +=1; //the amount of items within the players inventory is increased 
                break; //the loop is broken at the point at which a purchase is complete
            }
        }


        if (itemToBuy.CompareTag("Platform"))
        { //a conditional check to see whether the item that is bought is listed as "platform"
            BuyPlatform(itemToBuy); //the method is called along with the itemtoBuy gameobject
        }
    }


    public void BuyPlatform(GameObject platform)
    { //this method is called uniquely to process and handle the item purchase process of platforms
        if (player.Gold >= platform.GetComponentInChildren<Spawn>().itemPrice && _itemAmount > 0)
        { //conditional check to see if the player has enough currency and the shop as the required quantity to faciliate this purchase
            _itemAmount -= 1; //decreasing the item quanity of the buy station
            player.Gold -= platform.GetComponentInChildren<Spawn>().itemPrice;//decreasing the item price from the total of the players currency total

            // Set the platform to active
            platform.SetActive(true);
        }
    }




    public void Sell()
    { //this sell method is called uniquely to handle the sell process within the game
        for (int i = 0; i < inventory.slots.Length; i++)
        { //for loop is used as a means to iterate through each slot in the inventory array
            if (inventory.slots[i].transform.GetComponent<Slots>().amount != 0 )
            { //if condition is used as a means to check if the slots have any assigned item quantity
                if (itemName.text == inventory.slots[i].transform.GetComponentInChildren<Spawn>().itemName) //checking if the item in the shop has the same name as that in the inventory
                {
                    _itemAmount += 1; //increasing the item quantity held within the shop
                    inventory.slots[i].GetComponent<Slots>().amount -= 1; //decreasing the item amount within the players inventory system
                    player.Gold += itemToBuy.GetComponentInChildren<Spawn>().itemPrice / 2; //half of the item price is added to the players inventory system count
                    if(inventory.slots[i].GetComponent<Slots>().amount == 0)
                    { //conditional statement that checks if inventory slot amounts to zero
                        //inventory.slots[i].GetComponent<Slots>().ItemName.text = string.Empty;
                        GameObject.Destroy(inventory.slots[i].transform.GetComponentInChildren<Spawn>().gameObject);
                    }
                    break; //break function is used to break out of loop after sell process is conducted
                }
            }
        }
    }
}
