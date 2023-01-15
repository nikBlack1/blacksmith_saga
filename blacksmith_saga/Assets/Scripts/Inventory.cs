using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private bool isFull;
    [SerializeField] private bool isOpen;
    [SerializeField] private GameObject inventoryTemplate;
    [SerializeField] private GameObject inventoryObjectTemplate;

    private List<InventoryObject> _inventoryItems = new List<InventoryObject>();
    
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
    
    public InventoryObject AddNewInventoryItem(string title, int amount)
    {
        InventoryObject newInventoryObject = new InventoryObject(title, amount);
        GameObject inventoryObject = Instantiate(inventoryObjectTemplate);

        return newInventoryObject;
    }
    
    public void AddInventoryItemAmount(string title)
    {
        getSpecificInventoryObject(title).addAmount();
    }
    
    
    public void SubstractInventoryItemAmount(string title)
    {
        getSpecificInventoryObject(title).substractAmount();
    }
    
    
    public void DeleteInventoryItem(string title)
    {
        for(int i = 0; i < _inventoryItems.Count; i++)
        {
            if (title == _inventoryItems[i].getItemName())
            {
                _inventoryItems.RemoveAt(i);
            }
        }
    }

    
    [CanBeNull]
    private InventoryObject getSpecificInventoryObject(string title)
    {
        foreach (InventoryObject item in _inventoryItems)
        {
            if (title == item.getItemName())
            {
                return item;
            }
        }

        return null;
    }
    
}
