using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Slime : MonoBehaviour, IDamageable
{
    bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    public AIPath aiPath;

    Animator animator;

    new Rigidbody2D rigidbody;

    bool isAlive = true;
    bool isMoving = false;

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

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(0.32f, 0.32f, 1f);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-0.32f, 0.32f, 1f);
        }
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;

        //rigidbody.AddForce(knockback);
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }
}
