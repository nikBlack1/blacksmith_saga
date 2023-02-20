using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Inventory : MonoBehaviour
{
    //private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    public int selectedItemIndex = 0;
    
    public static UI_Inventory instance;

    public GameObject selector;

    private void Awake()
    {
        // itemSlotSelector = transform.Find("Selector");
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");

        //inventory = inventory.instance;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // bool selectLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        // bool selectRight = Input.GetKeyDown(KeyCode.RightArrow);
        //
        // if (selectLeft)
        // {
        //     moveSelectorLeft();
        // }
        // if (selectRight)
        // {
        //     moveSelectorRight();
        // }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedItemIndex = 0;

            Debug.Log("1 was clicked");
            correctSelector();
            RefreshInventoryItems();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            selectedItemIndex = 1;
            Debug.Log("2 was clicked");
            correctSelector();
            RefreshInventoryItems();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            selectedItemIndex = 2;
            Debug.Log("2 was clicked");
            correctSelector();
            RefreshInventoryItems();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) 
        {
            selectedItemIndex = 3;
            Debug.Log("2 was clicked");
            correctSelector();
            RefreshInventoryItems();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) 
        {
            selectedItemIndex = 4;
            Debug.Log("2 was clicked");
            correctSelector();
            RefreshInventoryItems();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) 
        {
            selectedItemIndex = 5;
            Debug.Log("2 was clicked");
            correctSelector();
            RefreshInventoryItems();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) 
        {
            selectedItemIndex = 6;
            Debug.Log("2 was clicked");
            correctSelector();
            RefreshInventoryItems();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) 
        {
            selectedItemIndex = 7;
            Debug.Log("2 was clicked");
            correctSelector();
            RefreshInventoryItems();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9)) 
        {
            selectedItemIndex = 8;
            Debug.Log("2 was clicked");
            correctSelector();
            RefreshInventoryItems();
        }
    }

    // public void SetInventory(Inventory inventory)
    // {
    //     this.inventory = inventory;
    //     //inventory.OnItemListChanged += Inventory_OnItemListChanged;
    //     RefreshInventoryItems();
    // }
    
    // private void Inventory_OnItemListChanged(object sender, System.EventArgs e) {
    //     RefreshInventoryItems();
    // }

    public void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 100f; 
        
        // foreach (var item in Inventory.instance.itemList)
        // {
        //     RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
        //     itemSlotRectTransform.gameObject.SetActive(true);
        //     
        //     itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
        //     Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
        //     image.sprite = item.GetSprite();
        //
        //     TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
        //     uiText.SetText(item.amount.ToString());
        //     x++;
        // }
 
        var inventoryList = Inventory.instance.itemList;
        
        for (int i = 0; i < inventoryList.Count; i++)
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = inventoryList[i].GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            uiText.SetText(inventoryList[i].amount.ToString());
            x++;
        }
 
        selector.transform.localPosition = new Vector2(selectedItemIndex * itemSlotCellSize, y * itemSlotCellSize);
    }

    public void moveSelectorLeft()
    {
        if (Inventory.instance.itemList.Count == 1)
        {
            selectedItemIndex = 0;
            return;
        }
        if (selectedItemIndex - 1 < 0)
        {
            selectedItemIndex = Inventory.instance.itemList.Count - 1;
        }

        selectedItemIndex -= 1;
    }
    
    public void moveSelectorRight()
    {
        if (Inventory.instance.itemList.Count == 1)
        {
            selectedItemIndex = 0;
            return;
        }
        if (selectedItemIndex + 1 > Inventory.instance.itemList.Count)
        {
            selectedItemIndex = 0;
        }

        selectedItemIndex -= 1;
    }

    public void correctSelector()
    {
        if (selectedItemIndex > Inventory.instance.itemList.Count - 1)
        {
            selectedItemIndex = Inventory.instance.itemList.Count - 1;
        }
    }
}
