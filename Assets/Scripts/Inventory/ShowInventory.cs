using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{

    public GameObject inventoryUI;

    [Header("Input")]
    public KeyCode Button = KeyCode.I;

    public static bool isInvemntoryUI;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Button))
        { 
            if(isInvemntoryUI)
            {
                HideInventoryUI();
            }
            else
            {
                ShowInventoryUI();
            }
        }


    }

    public void ShowInventoryUI()
    {
        inventoryUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideInventoryUI()
    {
        inventoryUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
