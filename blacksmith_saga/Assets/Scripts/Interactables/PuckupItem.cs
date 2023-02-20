using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PuckupItem : MonoBehaviour
{
    // --------------------------------------
    // ---- Object variables ----------------
    // -------------------------------------- 
    [SerializeField] private float speed = 2f;
    [SerializeField] private float pickupDistance = 2.5f;
    [SerializeField] private float despawnTime = 1000f;
    public int itemId;

    private Inventory _inventory;

    public GameObject _itemIcon;
    // -------------------------------------- 

        
        
    // --------------------------------------
    // ---- Reference variables -------------
    // --------------------------------------
    private Transform player;
    // -------------------------------------- 

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }


    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    private void Update()
    {
        despawnTime -= Time.deltaTime;
        if (despawnTime < 0)
        {
            Destroy(gameObject);
        }

        float distance = UnityEngine.Vector3.Distance(transform.position, player.position);
        
        Debug.Log(distance);
        Debug.Log(distance > pickupDistance);

        
        if (distance > pickupDistance)
        {
            return;
        }

        transform.position = UnityEngine.Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (distance < 0.1f)
        {
            //ResourcesManager.instance.blueShardsAmount += 1; //f�r andere Ressourcen anpassen
            Item newItem = new Item();
            switch (itemId)
            {
                case 1:
                    newItem.itemType = Item.ItemType.BlueShard;
                    break;
                case 2:
                    newItem.itemType = Item.ItemType.RedShard;
                    break;
                case 3:
                    newItem.itemType = Item.ItemType.GoldShard;
                    break;
                case 4:
                    newItem.itemType = Item.ItemType.IronShard;
                    break; 
            }
            // _inventory.AddItem(newItem);
            //_inventory.instance.AddItem(new Item { itemType = Item.ItemType.BlueShard, amount = 1}); 

            Inventory.instance.AddItem(new Item { itemType = newItem.itemType, amount = 1 });
            Letterbox.instance.RefreshQuestUi();
            Destroy(gameObject);

        }
        
    }
}
