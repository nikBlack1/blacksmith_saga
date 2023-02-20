using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter : MonoBehaviour
{

    private bool _isNear = false; 
    public GameObject activationButtonHint;
    public SpriteRenderer uiSpriteRenderer;
    
    public GameObject letterbox;

    private void Awake()
    {
        uiSpriteRenderer = activationButtonHint.GetComponent<SpriteRenderer>();
        return;
    }

    private void Update()
    {
        uiSpriteRenderer.color = new Color(255, 255, 255, 0);
        bool isAcceptKeyDown = Input.GetKeyDown(KeyCode.G);
        bool isRefuseKeyDown = Input.GetKeyDown(KeyCode.R);
        bool isSmeltKeyDown = Input.GetKeyDown(KeyCode.E);

        if (_isNear)
        {
            uiSpriteRenderer.color = new Color(255, 255, 255, 255);

            if (isRefuseKeyDown)
            {
                QuestManager.Instance.refuseQuest();
                Debug.Log("QUEST WAS REFUSED");
                QuestManager.Instance.playRefuseSound();

            }
            if (isAcceptKeyDown)
            {
               if (!QuestManager.Instance.questOngoing)
               {
                   QuestManager.Instance.questOngoing = true;
                   Debug.Log("QUEST WAS ACCEPTED");
                   QuestManager.Instance.playTakenSound();

               } 
               if (QuestManager.Instance.questOngoing)
               {
                   QuestManager.Instance.completeQuest();
                   //QuestManager.Instance.playSuccessSound();
               } 
            }

            
            if (isSmeltKeyDown) 
            {
                Item selectedItem = Inventory.instance.itemList[UI_Inventory.instance.selectedItemIndex];
                Debug.Log(selectedItem.itemType); 
                if (QuestManager.Instance.questOngoing)
                {
                    Debug.Log("quest is going on");
                    // check if item is needed
                    if (itemIsNeeded(selectedItem))
                    {
                        // substract from inventory
                        Inventory.instance.itemList[UI_Inventory.instance.selectedItemIndex].amount -= 1;
                        
                        // substract from quest 
                        switch (selectedItem.itemType)
                        {   
                            default:
                            case Item.ItemType.BlueShard:
                                QuestManager.Instance.suggestedQuest.questItem._nBlue -= 1;
                                break;
                            case Item.ItemType.RedShard:
                                QuestManager.Instance.suggestedQuest.questItem._nRed -= 1;
                                break;
                            case Item.ItemType.IronShard:
                                QuestManager.Instance.suggestedQuest.questItem._nIron -= 1;
                                break;
                            case Item.ItemType.GoldShard:
                                QuestManager.Instance.suggestedQuest.questItem._nGold -= 1;
                                break;                    
                        }
                         
                        Letterbox.instance.RefreshQuestUi();
                        UI_Inventory.instance.RefreshInventoryItems();
                    }
                }

            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _isNear = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        _isNear = false;
    }

    public bool itemIsNeeded(Item item)
    {
        if (item.itemType == Item.ItemType.BlueShard)
        {
            // if the item is needed
            if (QuestManager.Instance.suggestedQuest.questItem._nBlue != -1)
            {
                // if the item is not yet 0
                if (QuestManager.Instance.suggestedQuest.questItem._nBlue != 0)
                {
                    return true;
                }
            }
        }
        if (item.itemType == Item.ItemType.RedShard)
        {
            // if the item is needed
            if (QuestManager.Instance.suggestedQuest.questItem._nRed != -1)
            {
                // if the item is not yet 0
                if (QuestManager.Instance.suggestedQuest.questItem._nRed != 0)
                {
                    return true;
                }
            }
        }
        if (item.itemType == Item.ItemType.IronShard)
        {
            // if the item is needed
            if (QuestManager.Instance.suggestedQuest.questItem._nIron != -1)
            {
                // if the item is not yet 0
                if (QuestManager.Instance.suggestedQuest.questItem._nIron != 0)
                {
                    return true;
                }
            }
        }
        if (item.itemType == Item.ItemType.GoldShard)
        {
            // if the item is needed
            if (QuestManager.Instance.suggestedQuest.questItem._nGold != -1)
            {
                // if the item is not yet 0
                if (QuestManager.Instance.suggestedQuest.questItem._nGold != 0) 
                {
                    return true;
                }
            }
        }

        return false;
    }
}
