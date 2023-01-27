using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    
    public static QuestManager Instance;

    public SmithingTask OngoingSmithingTask;
    private void Awake()
    {
        Instance = this;
    }


    public SmithingTask CreateSmithingTask(int reward, int fame, int chunksNeeded)
    {
        OngoingSmithingTask = new SmithingTask(reward, fame, chunksNeeded);
        return OngoingSmithingTask;
    }

    
    public SmithingTask GetOngoingSmithingTask()
    {
        return OngoingSmithingTask;
    }
    

    public void CompleteOngoingSmithingTask()
    {
        OngoingSmithingTask = null;
    }
}