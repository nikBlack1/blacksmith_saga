using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string unloadScene;
    [SerializeField] private string loadScene;
    private GameObject[] gameObjects;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

            SceneManager.UnloadSceneAsync(unloadScene);
            SceneManager.LoadScene(loadScene, LoadSceneMode.Additive);

            for (var i = 0; i < gameObjects.Length; i++)
                Destroy(gameObjects[i]);
        }
    }
}