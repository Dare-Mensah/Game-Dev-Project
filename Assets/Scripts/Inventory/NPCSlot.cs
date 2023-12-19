using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCSlot : MonoBehaviour
{
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
        itemName.text = itemToBuy.GetComponent<Spawn>().itemName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
