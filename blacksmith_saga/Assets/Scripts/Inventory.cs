using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> itemList;
    public event EventHandler OnItemListChanged;

    public static Inventory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
 
    public Inventory()
    {
        itemList = new List<Item>();

        // AddItem(new Item { itemType = Item.ItemType.BlueShard, amount = 1});
        // AddItem(new Item { itemType = Item.ItemType.GoldShard, amount = 1});
        //AddItem(new Item { itemType = Item.ItemType.IronShard, amount = 1});
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        bool itemIsAlreadyInside = false;
        
        foreach (var itemInList in itemList)
        {
            if (item.itemType == itemInList.itemType)
            {
                itemIsAlreadyInside = true;
                itemInList.amount += 1;
            }
        }

        if (!itemIsAlreadyInside)
        {
            itemList.Add(item);
        }
        
        UI_Inventory.instance.RefreshInventoryItems();
        //OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
