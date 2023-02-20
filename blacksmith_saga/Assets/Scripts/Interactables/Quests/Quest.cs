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
        // return -1 * (questItem._nIron * 1) + (questItem._nBlue * 2) + (questItem._nRed * 3) + (questItem._nGold * 4);
        return 5;
    }

    public int generateGoldBasedOnItem()
    {
        // return (questItem._nIron * 1) + (questItem._nBlue * 2) + (questItem._nRed * 2) + (questItem._nGold * 3);
        return 5;
    }
}
