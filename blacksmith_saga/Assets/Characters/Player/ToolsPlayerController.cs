using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsPlayerController : MonoBehaviour
{
    private PlayerController _player;
    private Rigidbody2D _rgb2d;
    [SerializeField] private float offsetDistance = 1f;
    [SerializeField] private float sizeOfInteractableArea = 1.1f;

private void Awake()
    {
        _player = GetComponent<PlayerController>();
        _rgb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UseTool();
        }
    }

    // trying to destroy on collision
    // private void OnCollisionEnter2D(Collider2D collider)
    // {
    //     // if crystal is minable
    //     ToolHit hit = collider.GetComponent<ToolHit>();
    //     if (hit != null)
    //     {
    //         // destroy the crystal
    //         hit.Hit();
    //     }
    // }

    // destroying on mouseclick - works, but radius is unclear
    private void UseTool()
    {
        Vector2 position = _rgb2d.position + _player.lastMotionVector * offsetDistance;

        //Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.2f);
        Debug.LogWarning(colliders);

        foreach (Collider2D collider in colliders)
        {
            // if crystal is minable
            ToolHit hit = collider.GetComponent<ToolHit>();
            if (hit != null)
            {
                // destroy the crystal
                hit.Hit();
                break;
            }
        }
    }
}
