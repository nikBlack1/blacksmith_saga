using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    
    public static ResourcesManager instance;

    public int moneyAmount;
    public Text moneyAmountDisplay;
    
    public int fameAmount;
    public Text fameAmountDisplay;

    public int dayAmount;
    public Text dayAmountDisplay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        moneyAmount = 0;
        fameAmount = 0;
        dayAmount = 1;
    }


    private void Update()
    {
        moneyAmountDisplay.text = moneyAmount.ToString();
        fameAmountDisplay.text = fameAmount.ToString();
        dayAmountDisplay.text = dayAmount.ToString();
    }
}