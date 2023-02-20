using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    
    // --------------------------------------
    // ---- Object variables ----------------
    // -------------------------------------- 
    public int _rewardFame;
    public int _rewardGold;
    public bool _isAccepted;

    public QuestItem questItem;
    // --------------------------------------

    public Quest()
    {
        this.questItem = new QuestItem();
        this._rewardFame = generateFameBasedOnItem();
        this._rewardGold= generateGoldBasedOnItem();
    }

    public int generateFameBasedOnItem()
    {
        int ironValue = 0;
        int blueValue = 0;
        int redValue = 0;
        int goldValue = 0;

        if (questItem._nIron > 0)
        {
            ironValue = questItem._nIron;
        }
        if (questItem._nBlue > 0)
        {
            blueValue = questItem._nBlue;
        }
        if (questItem._nRed > 0)
        {
            redValue = questItem._nRed;
        }
        if (questItem._nGold > 0)
        {
            goldValue = questItem._nGold;
        }

        return (ironValue * 1) + (blueValue * 2) + (redValue * 3) + (goldValue * 2);

        //return 5;
    }

    public int generateGoldBasedOnItem()
    {
        return (generateFameBasedOnItem() * generateFameBasedOnItem())/2;
        //return 5;
    }
}
