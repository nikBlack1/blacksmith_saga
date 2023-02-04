using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string unloadScene;
    [SerializeField] private string loadScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.UnloadSceneAsync(unloadScene);
            SceneManager.LoadScene(loadScene, LoadSceneMode.Additive);
        }
    }
}