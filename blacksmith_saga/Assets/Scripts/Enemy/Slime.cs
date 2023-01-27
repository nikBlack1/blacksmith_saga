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

    public float knockbackForce = 0.1f;
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
                damage = 0; 
                knockbackForce = 0;
            }
        }
        get
        {
            return health;
        }
    }

    public float health = 3;
    [SerializeField] private int damage = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
        rigidbody = GetComponent<Rigidbody2D>();
        this.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Slime_Damage") || animator.GetCurrentAnimatorStateInfo(0).IsName("Slime_Death"))
        {
            this.aiPath.canMove = false;
        }
        else
        {
            this.aiPath.canMove = true;
        }

        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(0.32f, 0.32f, 1f);

            if(this.aiPath.canMove)
            {
                animator.SetBool("isMoving", true);
            }
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-0.32f, 0.32f, 1f);

            if (this.aiPath.canMove)
            {
                animator.SetBool("isMoving", true);
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;

        this.aiPath.canMove = false;
        rigidbody.AddForce(knockback*10);
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;

            Vector2 direction = (Vector2)(collision.gameObject.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;

            collision.GetComponent<PlayerController>().OnHit(damage, knockback);
        }
    }
}
