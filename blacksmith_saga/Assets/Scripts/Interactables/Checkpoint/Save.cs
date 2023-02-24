using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private bool _isNear = false;
    public GameObject activationButtonHint;
    public SpriteRenderer uiSpriteRenderer;
    private GameObject player;

    private void Awake()
    {
        uiSpriteRenderer = activationButtonHint.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        return;
    }

    private void Update()
    {
        uiSpriteRenderer.color = new Color(255, 255, 255, 0);
        bool isKeyDown = Input.GetKeyDown(KeyCode.E);

        if (_isNear)
        {
            uiSpriteRenderer.color = new Color(255, 255, 255, 255);

            if (isKeyDown)
            {
                SaveGame();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            _isNear = true;
        }
       
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        _isNear = false;
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("money", ResourcesManager.instance.moneyAmount);
        PlayerPrefs.SetInt("fame", ResourcesManager.instance.fameAmount);

        PlayerPrefs.SetFloat("health", player.GetComponent<Health>().startingHealth);
        PlayerPrefs.SetFloat("damage", player.GetComponentInChildren<AttackArea>().damage);

        PlayerPrefs.SetString("itemName0", "");
        PlayerPrefs.SetString("itemName1", "");
        PlayerPrefs.SetString("itemName2", "");
        PlayerPrefs.SetString("itemName3", "");

        if (Inventory.instance.itemList.Count >= 1)
        {
            PlayerPrefs.SetInt("itemAmount0", Inventory.instance.itemList[0].amount);
            PlayerPrefs.SetString("itemName0", Inventory.instance.itemList[0].getItemTypeAsString());
            Debug.Log("1");

            if (Inventory.instance.itemList.Count >= 2)
            {
                PlayerPrefs.SetInt("itemAmount1", Inventory.instance.itemList[1].amount);
                PlayerPrefs.SetString("itemName1", Inventory.instance.itemList[1].getItemTypeAsString());
                Debug.Log("2");

                if (Inventory.instance.itemList.Count >= 3)
                {
                    PlayerPrefs.SetInt("itemAmount2", Inventory.instance.itemList[2].amount);
                    PlayerPrefs.SetString("itemName2", Inventory.instance.itemList[2].getItemTypeAsString());
                    Debug.Log("3");

                    if (Inventory.instance.itemList.Count >= 4)
                    {
                        PlayerPrefs.SetInt("itemAmount3", Inventory.instance.itemList[3].amount);
                        PlayerPrefs.SetString("itemName3", Inventory.instance.itemList[3].getItemTypeAsString());
                        Debug.Log("4");
                    }
                }
            }
        }

        FindObjectOfType<GameManager>().RespawnPlayer(0f);

        ResourcesManager.instance.dayAmount = ResourcesManager.instance.dayAmount + 1;
        PlayerPrefs.SetInt("day", ResourcesManager.instance.dayAmount);
    }
}
