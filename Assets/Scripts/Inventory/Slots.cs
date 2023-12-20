using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slots : MonoBehaviour
{
    private InventoryController inventory;

    public int i;

    public TextMeshProUGUI amountText;

    public int amount;

    public TextMeshProUGUI ItemName;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        amountText.text = amount.ToString();

        if(amount > 1)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }



        if(transform.childCount == 2)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem()
    {
        if(amount > 1) // if the itme is stacked
        {
            amount -= 1;
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem();
        }
        else
        {
            amount -= 1;
            GameObject.Destroy(transform.GetComponentInChildren<Spawn>().gameObject);
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem();
        }
    }
}
