using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCSlot : MonoBehaviour
{
    private PlayerInventory player;
    private InventoryController inventory;
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemPrice;
    public TextMeshProUGUI itemAmount;

    public GameObject itemToBuy;
    public int _itemAmount;
    public TextMeshProUGUI buyPriceText;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerInventory>();
        inventory = FindObjectOfType<InventoryController>();
        itemName.text = itemToBuy.GetComponent<Spawn>().itemName;
        itemImage.sprite = itemToBuy.GetComponent<Image>().sprite;
        buyPriceText.text = itemToBuy.GetComponentInChildren<Spawn>().itemPrice + " Gold"; //shjowing price
    }

    // Update is called once per frame
    void Update()
    {
        itemAmount.text = "Amount: " + _itemAmount.ToString(); //showing the amoutn for the item
    }

    public void Buy()
    {
        for (int i = 0; i < inventory.slots.Length; i++) 
        {
            if(inventory.isFull[i] == true && inventory.slots[i].transform.GetComponent<Slots>().amount < 20 && player.Gold >= itemToBuy.GetComponentInChildren<Spawn>().itemPrice && _itemAmount > 0) 
            {
                if (itemName.text == inventory.slots[i].transform.GetComponentInChildren<Spawn>().itemName) //checking if the item in the shop has the same name as that in the inventory
                {
                    _itemAmount -= 1; //removing from shop
                    inventory.slots[i].GetComponent<Slots>().amount += 1; //adding to inventory
                    player.Gold -= itemToBuy.GetComponentInChildren<Spawn>().itemPrice; //deducting the gold
                    break;
                }
            }

            else if(inventory.isFull[i] == false && player.Gold >= itemToBuy.GetComponentInChildren<Spawn>().itemPrice && _itemAmount > 0)
            {
                _itemAmount -= 1;
                player.Gold -= itemToBuy.GetComponentInChildren<Spawn>().itemPrice;
                inventory.slots[i].GetComponent<Slots>().ItemName.text = itemName.text;
                inventory.isFull[i] = true;
                Instantiate(itemToBuy, inventory.slots[i].transform, false);
                inventory.slots[i].GetComponent<Slots>().amount +=1;
                break;
            }
        }
    }

    public void Sell()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].transform.GetComponent<Slots>().amount != 0 )
            {
                if (itemName.text == inventory.slots[i].transform.GetComponentInChildren<Spawn>().itemName) //checking if the item in the shop has the same name as that in the inventory
                {
                    _itemAmount += 1;
                    inventory.slots[i].GetComponent<Slots>().amount -= 1;
                    player.Gold += itemToBuy.GetComponentInChildren<Spawn>().itemPrice / 2;
                    if(inventory.slots[i].GetComponent<Slots>().amount == 0)
                    {
                        //inventory.slots[i].GetComponent<Slots>().ItemName.text = string.Empty;
                        GameObject.Destroy(inventory.slots[i].transform.GetComponentInChildren<Spawn>().gameObject);
                    }
                    break;
                }
            }
        }
    }
}
