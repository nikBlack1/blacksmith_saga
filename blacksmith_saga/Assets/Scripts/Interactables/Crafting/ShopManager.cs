using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _isNearDamage;
    private bool _isNearHealth;
    private Transform shopUi;
    private Transform playerAttackArea;
    private Transform player;


    private void Awake()
    {
        playerAttackArea = transform.Find("AttackArea");
        player = transform.Find("Player");

        shopUi = transform.Find("ShopUI");
        shopUi.gameObject.SetActive(false);
        
        bool isActionKeyAccept = Input.GetKeyDown(KeyCode.E);

        // if (_isNear)
        // {
        //     if (isDamageKeyAccept)
        //     {
        //         buyDamage();
        //     }
        //
        //     if (isHealthKeyAccept)
        //     {
        //         buyHealth();
        //     }
        // }

    }

    private void Update()
    {
        throw new NotImplementedException();
    }
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            // _isNear = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        // _isNear = false;
    }

    public void buyHealth()
    {
        if (ResourcesManager.instance.moneyAmount >= 100)
        {
            ResourcesManager.instance.moneyAmount -= 100;
            player.GetComponent<Health>().buyNewHealth();
        }
    }
    
    public void buyDamage()
    {
        if (ResourcesManager.instance.moneyAmount >= 15)
        {
            ResourcesManager.instance.moneyAmount -= 10;
            playerAttackArea.GetComponent<AttackArea>().damage += 5;
        }
    }
    
    
}
