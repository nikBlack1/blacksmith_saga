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
    // -------------------------------------- 

        
        
    // --------------------------------------
    // ---- Reference variables -------------
    // --------------------------------------
    private Transform player;
    // -------------------------------------- 




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
            ResourcesManager.instance.blueShardsAmount += 1; //für andere Ressourcen anpassen
            Destroy(gameObject);
        }
        
    }
}
