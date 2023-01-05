using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private bool isFull;
    [SerializeField] private bool isOpen;
    [SerializeField] private GameObject inventoryTemplate;
    public static Inventory instance;


    private void Awake()
    {
        isOpen = false;
        inventoryTemplate = GameObject.Find("InventoryTemplate");
        inventoryTemplate.SetActive(false);

    }

    private void Update()
    {
        bool triggerInventory = Input.GetKeyDown(KeyCode.I);

        if (triggerInventory)
        {
            SwitchInventoryVisibility();
        }
    }


    private void SwitchInventoryVisibility()
    {
        if (isOpen)
        {
            inventoryTemplate.SetActive(false);
            isOpen = false;
        }
        else
        {
            inventoryTemplate.SetActive(true);
            isOpen = true;
        }
    }
    
    
}
