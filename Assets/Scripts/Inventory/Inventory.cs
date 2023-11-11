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
        if(CountC == 3)
        {
            NPC.SetActive(true);
        }
    }

    public void AddItem(Item itemToAdd)
    {
        bool itemExists = false;

        foreach (Item item in items)
        {
            if(item.name == itemToAdd.name)
            {
                item.count += itemToAdd.count;
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
        foreach (var item in items)
        {
            if(item.name == itemToRemove.name)
            {
                item.count -= itemToRemove.count;
                if(item.count <= 0)
                {
                    items.Remove(itemToRemove);
                }
                break;
            }
        }

        Debug.Log(itemToRemove.count + " " + itemToRemove.name + "removed from inventory");
    }
}
