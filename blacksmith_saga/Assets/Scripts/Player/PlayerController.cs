using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    new public Rigidbody2D rigidbody;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Collider2D attackCollider;

    Vector2 movementInput = Vector2.zero;

    public bool canMove = true;
    bool isMoving = false;

    //[SerializeField] private UI_Inventory uiInventory;
    //private Inventory _inventory;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attackCollider = attackArea.GetComponent<Collider2D>();

        // _inventory = new Inventory();
        // uiInventory.SetInventory(_inventory);
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

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().dead || animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Hurt"))
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }


        //Übergangsweise zum schließen des Spiels
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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

    public void OnHit(float damage, Vector2 knockback)
    {
        this.GetComponent<Health>().TakeDamage(damage);

        rigidbody.AddForce(knockback*10);
    }
}
