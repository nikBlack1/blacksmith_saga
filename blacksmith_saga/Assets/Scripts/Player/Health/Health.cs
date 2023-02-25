using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth { get; set; }
    private Animator anim;
    public bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }


    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                dead = true;
            }
        }
    }

    public void buyNewHealth()
    {
        startingHealth += 1;
        currentHealth += 1;
        FindObjectOfType<Healthbar>().totalhealthBar.fillAmount += 0.1f;
    }
}
