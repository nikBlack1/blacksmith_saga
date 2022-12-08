using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{ 
    private Transform _player;
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float pickUpDistance = 1.5f;
    [SerializeField] private float ttl = 10f;

    private void Awake()
    {
        _player = GameManager.instance.player.transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.position);
        
        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            _player.position,
            speed * Time.deltaTime
        );

        if (distance < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
