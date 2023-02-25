using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private bool _isNear = false;
    public GameObject activationButtonHint;
    public SpriteRenderer uiSpriteRenderer;
    private GameObject player;
    [SerializeField] string mode;

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
                if (mode == "Health")
                {
                    BuyHealth();
                }
                if (mode == "Damage")
                {
                    BuyDamage();
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            _isNear = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        _isNear = false;
    }

    public void BuyHealth()
    {
        if (ResourcesManager.instance.moneyAmount >= 10)
        {
            if(player.GetComponent<Health>().startingHealth < 6)
            {
                ResourcesManager.instance.moneyAmount -= 10;
                player.GetComponent<Health>().buyNewHealth();
            }
        }
    }
    
    public void BuyDamage()
    {
        if (ResourcesManager.instance.moneyAmount >= 10)
        {
            if(player.GetComponentInChildren<AttackArea>().damage < 2)
            {
                ResourcesManager.instance.moneyAmount -= 10;
                player.GetComponentInChildren<AttackArea>().damage += 0.25f;
            }
        }
    }
    
    
}
