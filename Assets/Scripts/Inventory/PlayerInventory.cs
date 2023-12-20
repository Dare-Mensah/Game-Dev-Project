using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{

    public int Gold;
    public TextMeshProUGUI GoldAmountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoldAmountText.text = Gold + " Gold";
    }
}
