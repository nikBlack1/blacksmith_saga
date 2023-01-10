using System;
using UnityEngine;


public class InventoryObject
{
    private string _title;
    private int _amount;

    public InventoryObject(string title, int amount)
    {
        _title = title;
        _amount = amount;
    }

    public string getItemName()
    {
        return _title;
    }
    
    public void substractAmount()
    {
        _amount -= 1;
    }
    
    public void addAmount()
    {
        _amount += 1;
    }
}
