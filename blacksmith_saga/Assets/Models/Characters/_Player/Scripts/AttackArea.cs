using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public float damage = 1f;
    public float knockbackForce = 5000f;

    public Collider2D areaCollider;

    Vector3 faceRight = new Vector3(-0.7f, 0.1f, 0);
    Vector3 faceLeft = new Vector3(0.1f, 0.1f, 0);

    private void Start()
    {
        if (areaCollider == null)
        {
            Debug.LogWarning("Attack Collider not set");
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageableObject = collider.GetComponent<IDamageable>();

        if (damageableObject != null)
        {
            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;

            Vector2 direction = (Vector2)(collider.gameObject.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;

            //collider.SendMessage("OnHit", damage, knockback);
            damageableObject.OnHit(damage, knockback);
        }
        else
        {
            //Debug.LogWarning("Collider does not implement IDamageable");
        }
    }

    void IsFacingRight(bool isFacingRight)
    {
        if (isFacingRight)
        {
            gameObject.transform.localPosition = faceRight;
        }
        else
        {
            gameObject.transform.localPosition = faceLeft;
        }
    }
    /*
    Vector2 CalculateKnockback()
    {
        GameObject character = gameObject.getParent;
    }
    */
}
