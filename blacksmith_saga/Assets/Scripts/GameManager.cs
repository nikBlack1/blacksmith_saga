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
    }

    public void RespawnPlayer()
    {
        if(playerRespawn == false)
        {
            playerRespawn = true;
            Invoke("Restart", restartDelay);
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
}
