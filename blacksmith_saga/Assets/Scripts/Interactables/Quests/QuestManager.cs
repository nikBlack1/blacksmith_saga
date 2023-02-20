using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    
    public static QuestManager Instance;
    public Quest suggestedQuest;
    public bool questOngoing = false;
    
    public AudioSource audioSource;
    public AudioClip openSoundClip;
    public AudioClip closeSoundClip;
    public AudioClip takenSoundClip;
    public AudioClip successSoundClip;
    public AudioClip refuseSoundClip;


    private void Awake()
    {
        Instance = this;
        generateQuest();
        
        Debug.Log(suggestedQuest.questItem.GetSprite()); 
    }

    public void generateQuest()
    {
        this.suggestedQuest = new Quest();
        Letterbox.instance.RefreshQuestUi();
    }

    public void acceptQuest()
    {
        questOngoing = true;
        Letterbox.instance.RefreshQuestUi();
    }

    public bool completeQuest()
    {
        if (questOngoing)
        {
            var reqsFulfilled = false;
            
            if (suggestedQuest.questItem._nBlue == -1 || suggestedQuest.questItem._nBlue == 0)
            {
                reqsFulfilled = true;
            }
            else
            {
                return false;
            }
            if (suggestedQuest.questItem._nRed == -1 || suggestedQuest.questItem._nRed == 0)
            {
                reqsFulfilled = true;
            }
            else
            {
                return false;
            }
            if (suggestedQuest.questItem._nIron == -1 || suggestedQuest.questItem._nIron == 0)
            {
                reqsFulfilled = true;
            }
            else
            {
                return false;
            }
            if (suggestedQuest.questItem._nGold == -1 || suggestedQuest.questItem._nGold == 0)
            {
                reqsFulfilled = true;
            }
            else
            {
                return false;
            }

            if (reqsFulfilled)
            {
                ResourcesManager.instance.moneyAmount += suggestedQuest._rewardGold;
                ResourcesManager.instance.fameAmount += suggestedQuest._rewardFame;

                questOngoing = false;
                this.suggestedQuest = null;
                generateQuest();
                return true;
            }
        }
        return false;
    }
    
    public bool refuseQuest()
    {
        questOngoing = false;
        this.suggestedQuest = null;
        generateQuest();
        return true;
    }

    public void playOpenSound()
    {
        audioSource.PlayOneShot(openSoundClip);
    }

    public void playCloseSound()
    {
        audioSource.PlayOneShot(closeSoundClip);
    }
    
    public void playSuccessSound()
    {
        audioSource.PlayOneShot(successSoundClip);
    }
    
    public void playTakenSound()
    {
        audioSource.PlayOneShot(takenSoundClip);
    }
    
    public void playRefuseSound()
    {
        audioSource.PlayOneShot(refuseSoundClip);
    }
}