using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    
    public static GameManager instance;
    public GameObject player;
    public int crystalsAmount;
    private void Awake()
    {
        instance = this;
        crystalsAmount = 0;
    }
    
    
}
