using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IDamageable
{
    Animator animator;

    Rigidbody2D rigidbody;

    bool isAlive = true;

    public float Health
    {
        set
        {
            if(value < health)
            {
                animator.SetTrigger("hit");
            }

            health = value;

            if (health <= 0)
            {
                animator.SetBool("isAlive", false);
            }
        }
        get
        {
            return health;
        }
    }

    public float health = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;

        rigidbody.AddForce(knockback);
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }
}
