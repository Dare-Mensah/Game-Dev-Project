using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    public GameObject NPC;

    //public TMP_Text CoinCount;
    public int CountC = 1;


    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        if(CountC == 3) // for tutroial purpose SET TO BE CHNAGED
        {
            NPC.SetActive(true);
        }
    }

    public void AddItem(Item itemToAdd)
    {
        bool itemExists = false;

        foreach (Item item in items) // iterates through each item in the inventory
        {
            if(item.name == itemToAdd.name) // if the item is the item that we want to add
            {
                item.count += itemToAdd.count; // it increments the amount of that item in the inventory
                itemExists = true;
                break;
            }
        }
        if(!itemExists)
        {
            items.Add(itemToAdd);
        }
        CountC += 1;
    }

    public void RemoveItem(Item itemToRemove)
    {
        foreach (var item in items) // iterates through each item in the inventory
        {
            if(item.name == itemToRemove.name) // if the item is the item that we want to remove
            {
                item.count -= itemToRemove.count; // it decremnets the amount of that item in the inventory
                if(item.count <= 0) // if the item is less than or equal to zero we remove the item entriely
                {
                    items.Remove(itemToRemove);
                }
                break;
            }
        }

        Debug.Log(itemToRemove.count + " " + itemToRemove.name + "removed from inventory");// for devbugging purposes 
    }
}
