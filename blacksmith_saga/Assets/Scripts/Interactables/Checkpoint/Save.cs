using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private bool _isNear = false;
    public GameObject activationButtonHint;
    public SpriteRenderer uiSpriteRenderer;

    private void Awake()
    {
        uiSpriteRenderer = activationButtonHint.GetComponent<SpriteRenderer>();
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
                PlayerPrefs.SetFloat("money", ResourcesManager.instance.moneyAmount);
                PlayerPrefs.SetFloat("fame", ResourcesManager.instance.fameAmount);
                
                FindObjectOfType<GameManager>().RespawnPlayer(0f);

                ResourcesManager.instance.dayAmount = ResourcesManager.instance.dayAmount + 1;
                PlayerPrefs.SetInt("day", ResourcesManager.instance.dayAmount);
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
}
