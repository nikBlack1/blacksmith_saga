using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public Vector2 respawnPosition;

    public bool playerRespawn = false;
    public bool isLoaded = false;
    public float restartDelay = 1f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (isLoaded == true)
        {
            Debug.Log("loaded");
            try { LoadData(); } catch(Exception) { }
        }
    }

    public void RespawnPlayer()
    {
        if(playerRespawn == false)
        {
            playerRespawn = true;
            Invoke("Restart", restartDelay);
            foreach (Item item in Inventory.instance.itemList)
            {
                item.amount = Mathf.RoundToInt(item.amount / 3);
            }
            ResourcesManager.instance.moneyAmount = Mathf.RoundToInt(ResourcesManager.instance.moneyAmount / 3);
            ResourcesManager.instance.fameAmount = Mathf.RoundToInt(ResourcesManager.instance.fameAmount / 3);
            UI_Inventory.instance.RefreshInventoryItems();
        }
    }

    public void RespawnPlayer(float _restartDelay)
    {
        if (playerRespawn == false)
        {
            playerRespawn = true;
            Invoke("Restart", _restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Player");
        SceneManager.LoadScene("Home", LoadSceneMode.Additive);
    }

    public void LoadData()
    {
        ResourcesManager.instance.moneyAmount = PlayerPrefs.GetInt("money");
        ResourcesManager.instance.fameAmount = PlayerPrefs.GetInt("fame");

        if (PlayerPrefs.GetString("itemName0") != "")
        {
            Inventory.instance.AddItemFromString(PlayerPrefs.GetString("itemName0"), PlayerPrefs.GetInt("itemAmount0"));

            if (PlayerPrefs.GetString("itemName1") != "")
            {
                Inventory.instance.AddItemFromString(PlayerPrefs.GetString("itemName1"), PlayerPrefs.GetInt("itemAmount1"));

                if (PlayerPrefs.GetString("itemName2") != "")
                {
                    Inventory.instance.AddItemFromString(PlayerPrefs.GetString("itemName2"), PlayerPrefs.GetInt("itemAmount2"));

                    if (PlayerPrefs.GetString("itemName3") != "")
                    {
                        Inventory.instance.AddItemFromString(PlayerPrefs.GetString("itemName3"), PlayerPrefs.GetInt("itemAmount3"));
                    }
                }
            }
        }

        ResourcesManager.instance.dayAmount = PlayerPrefs.GetInt("day");

        isLoaded = false;
    }
}
