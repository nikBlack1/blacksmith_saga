using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    public float moveSpeed = 150f;
    public float maxSpeed = 8f;
    public float idleFriction = 0.9f;
    public GameObject attackArea;

    new Rigidbody2D rigidbody;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Collider2D attackCollider;

    Vector2 movementInput = Vector2.zero;

    bool canMove = true;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attackCollider = attackArea.GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (canMove == true && movementInput != Vector2.zero)
        {
            rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity + (movementInput * moveSpeed * Time.deltaTime), maxSpeed);

            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", true);
            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", false);
            }

            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("attack");
    }
    

    public void Attack()
    {
        LockMovement();
    }

    public void EndAttack()
    {
        UnlockMovement();
    }
    
    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
