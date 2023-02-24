using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenü : MonoBehaviour { 

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Home", LoadSceneMode.Additive);
    }

    public void LoadGame()
    {
        FindObjectOfType<GameManager>().isLoaded = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Home", LoadSceneMode.Additive);
        
    }

    public void QuitGame () 
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
