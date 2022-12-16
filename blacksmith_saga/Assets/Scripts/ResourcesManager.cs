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
    private void Awake()
    {
        instance = this;
        blueShardsAmount = 0;
        blueChunksAmount = 0;
    }


    private void Update()
    {
        blueShardsDisplay.text = blueShardsAmount.ToString();
        blueChunksDisplay.text = blueChunksAmount.ToString();
    }
}