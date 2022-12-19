using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    
    public static ResourcesManager instance;
    
    public int blueShardsAmount;
    public Text blueShardsDisplay;
    
    public int blueChunksAmount;
    public Text blueChunksDisplay;
    
    public int moneyAmount;
    public Text moneyAmountDisplay;
    
    public int fameAmount;
    public Text fameAmountDisplay;
    
    private void Awake()
    {
        instance = this;
        blueShardsAmount = 0;
        blueChunksAmount = 0;
        moneyAmount = 0;
        fameAmount = 0;
    }


    private void Update()
    {
        blueShardsDisplay.text = blueShardsAmount.ToString();
        blueChunksDisplay.text = blueChunksAmount.ToString();
        moneyAmountDisplay.text = moneyAmount.ToString();
        fameAmountDisplay.text = fameAmount.ToString();
    }
}