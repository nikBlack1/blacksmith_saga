using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class QuestItem
{

    // --------------------------------------
    // ---- Object variables ----------------
    // -------------------------------------- 
    public string _title;

    public enum ItemType
    {
        ringBlue,
        ringRed,
        shield,
        sword,
        armor
    }
    
    public enum ItemMaterial
    {
        iron,
        blue,
        red,
        gold
    }
    
    public ItemType itemType;
    public ItemMaterial itemMaterial;
    public int _nRed = -1;
    public int _nBlue = -1;
    public int _nIron = -1;
    public int _nGold = -1;
    // --------------------------------------
    
    
    public QuestItem()
    {
        this.itemType = GenerateRandomItemType();
        //Debug.Log(itemType); 
        this.itemMaterial = GenerateRandomItemMaterial();
        this._title = GenerateItemName();
    }
    
    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.ringBlue: return QuestItemAssets.Instance.ringBlue;
            case ItemType.ringRed: return QuestItemAssets.Instance.ringRed;
            case ItemType.shield: return QuestItemAssets.Instance.shield;
            case ItemType.sword: return QuestItemAssets.Instance.sword;
            case ItemType.armor: return QuestItemAssets.Instance.armor;
        }
    }
    
    public ItemType GenerateRandomItemType()
    {
        Random r = new Random();
        int rInt = r.Next(0, 4);
        switch (rInt)
        {            
            default:
            case 0:
                _nGold = 0;
                _nBlue = 0;
                // this._nGold += 10;
                // this._nBlue += 5;                
                this._nGold += 2;
                this._nBlue += 1;
                return ItemType.ringBlue;
            
            case 1:
                _nRed = 0;
                _nGold = 0;
                // this._nRed += 5;
                // this._nGold += 10;                
                this._nRed += 1;
                this._nGold += 2;
                return ItemType.ringRed;
            
            case 2:
                _nIron = 0;
                // this._nIron += 5;
                this._nIron += 2;
                return ItemType.sword;
            
            case 3:
                _nIron = 0;
                //this._nIron += 20;
                this._nIron += 3;
                return ItemType.armor;
            
            case 4:
                _nIron = 0;
                //this._nIron += 10;
                this._nIron += 2;
                return ItemType.shield;
        }
    }

    public ItemMaterial GenerateRandomItemMaterial()
    {
        Random r = new Random();
        int rInt = r.Next(0, 3);
        switch (rInt)
        {
            default: 
            case 0:
                if (_nRed == -1)
                {
                    _nRed = 0;
                }
                //this._nRed += 5;
                this._nRed += 1;
                return ItemMaterial.red;            
            
            case 1:
                if (_nBlue == -1)
                {
                    _nBlue = 0;
                }
                // this._nBlue += 5;
                this._nBlue += 1;
                return ItemMaterial.blue;
            
            case 2:
                if (_nIron == -1)
                {
                    _nIron = 0;
                }
                //this._nIron += 5;
                this._nIron += 2;
                return ItemMaterial.iron;   
            
            case 3:
                if (_nGold == -1)
                {
                    _nGold = 0;
                }
                // this._nGold += 5;
                this._nGold += 2;
                return ItemMaterial.gold;
        }
    }
    


    public string GenerateItemName()
    {
        var first = "";
        var second = "";
        
        switch (this.itemType)
        {
            default:
            case ItemType.ringBlue:
                first = "Blue ring of ";       
                break;
            
            case ItemType.ringRed:
                first = "Red ring of ";      
                break;
            
            case ItemType.armor:
                first = "Armor of ";  
                break;

            case ItemType.sword:
                first = "Sword of "; 
                break;

            case ItemType.shield:
                first = "Shield of ";
                break;

        }
        
        switch (this.itemMaterial)
        {
            default:
            case ItemMaterial.blue:
                second = "the sky";       
                break;
            
            case ItemMaterial.red:
                second = "the blood";      
                break;
            
            case ItemMaterial.iron:
                second = "the might";  
                break;

            case ItemMaterial.gold:
                second = "the sun"; 
                break;
        }

        return first + second;
    }
}
