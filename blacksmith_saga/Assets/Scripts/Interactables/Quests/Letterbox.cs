using UnityEngine;
using Random = System.Random;
using Math = System.Math;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;



public class Letterbox : MonoBehaviour
{

    public static Letterbox instance;
    
    private bool _isNear = false;
    private Transform letterboxUi;
    private Transform dynamicElements;
    private Transform itemTitle;

    private RectTransform dynamicElementsRectTransform;
    
    //public GameObject itemImage;

    

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
        letterboxUi = transform.Find("LetterboxUi"); 
        dynamicElements = letterboxUi.Find("DynamicElements");
        //itemImage = dynamicElements.Find("ItemImage");
        itemTitle = dynamicElements.Find("ItemTitle");
        
        dynamicElementsRectTransform = Instantiate(dynamicElements, letterboxUi).GetComponent<RectTransform>();
        letterboxUi.gameObject.SetActive(false);

        RefreshQuestUi(); 

    }

    private void FixedUpdate()
    {

        bool isKeyAccept = Input.GetKeyDown(KeyCode.E);
        bool isKeyRefuse = Input.GetKeyDown(KeyCode.N);
        
        if (_isNear)
        {
            //letterboxUi.gameObject.SetActive(true);
            
            // if no active quest
            if (!QuestManager.Instance.questOngoing)
            {
                if (isKeyAccept)
                {
                    QuestManager.Instance.questOngoing = true;
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {

            letterboxUi.gameObject.SetActive(true);
            _isNear = true;
            QuestManager.Instance.playOpenSound();

        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {   
        letterboxUi.gameObject.SetActive(false);
        _isNear = false;
        QuestManager.Instance.playCloseSound();
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        //
    }

    public void RefreshQuestUi()
    {
        //itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
        Image image = dynamicElementsRectTransform.Find("ItemImage").GetComponent<Image>();
        image.sprite = QuestManager.Instance.suggestedQuest.questItem.GetSprite();
        
        TextMeshProUGUI uiTitle = dynamicElementsRectTransform.Find("Title").GetComponent<TextMeshProUGUI>();
        uiTitle.SetText(QuestManager.Instance.suggestedQuest.questItem._title.ToString());
        
        TextMeshProUGUI nIron = dynamicElementsRectTransform.Find("nIron").GetComponent<TextMeshProUGUI>();
        if (isRequired(QuestManager.Instance.suggestedQuest.questItem._nIron))
        {
            nIron.SetText(QuestManager.Instance.suggestedQuest.questItem._nIron.ToString());
        }
        else
        {
            nIron.SetText("Not required");
        }
        
        TextMeshProUGUI nGold = dynamicElementsRectTransform.Find("nGold").GetComponent<TextMeshProUGUI>();
        if (isRequired(QuestManager.Instance.suggestedQuest.questItem._nGold))
        {
            nGold.SetText(QuestManager.Instance.suggestedQuest.questItem._nGold.ToString());
        }
        else
        {
            nGold.SetText("Not required");
        }
        
        TextMeshProUGUI nBlue = dynamicElementsRectTransform.Find("nBlue").GetComponent<TextMeshProUGUI>();
        if (isRequired(QuestManager.Instance.suggestedQuest.questItem._nBlue))
        {
            nBlue.SetText(QuestManager.Instance.suggestedQuest.questItem._nBlue.ToString());
        }
        else
        {
            nBlue.SetText("Not required");
        }
        
        TextMeshProUGUI nRed = dynamicElementsRectTransform.Find("nRed").GetComponent<TextMeshProUGUI>();
        if (isRequired(QuestManager.Instance.suggestedQuest.questItem._nRed))
        {
            nRed.SetText(QuestManager.Instance.suggestedQuest.questItem._nRed.ToString());
        }
        else
        {
            nRed.SetText("Not required");
        }
        
        
        TextMeshProUGUI rFame = dynamicElementsRectTransform.Find("rFame").GetComponent<TextMeshProUGUI>();
        rFame.SetText(QuestManager.Instance.suggestedQuest._rewardFame.ToString());
        
        TextMeshProUGUI rGold = dynamicElementsRectTransform.Find("rGold").GetComponent<TextMeshProUGUI>();
        rGold.SetText(QuestManager.Instance.suggestedQuest._rewardGold.ToString());
    }

    public bool isRequired(int number)
    {
        if (number == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
