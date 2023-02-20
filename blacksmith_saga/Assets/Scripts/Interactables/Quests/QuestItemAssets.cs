using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemAssets : MonoBehaviour
{
    public static QuestItemAssets Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite armor;
    public Sprite ringBlue;
    public Sprite ringRed;
    public Sprite sword;
    public Sprite shield;
    
}
