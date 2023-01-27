using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
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
