using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Interfaces;
using UnityEngine;

public class Crystal : MonoBehaviour, IDamageable
{
    
    
    // --------------------------------------
    // ---- Object variables ----------------
    // -------------------------------------- 
    [SerializeField] private float health = 3;
     private int dropCount = 5;
    [SerializeField] private float spread = 2f;
    [SerializeField] private GameObject drop;
    
    // --------------------------------------
    
    
    // --------------------------------------
    // ---- Reference variables -------------
    // --------------------------------------
    SpriteRenderer sr;
    // --------------------------------------
    
    
    public float Health
    {
        set
        {
            if(value < health)
            {
                // animator.SetTrigger("hit");
                // CHANGE COLOR HERE
                sr.color = new Color(0,255,240);//set this object's red color to 200 percent
            }

            health = value;

            if (health <= 0)
            {
                while (dropCount > 0)
                {
                    dropCount  -= 1;
                    Vector3 pos = transform.position;
                    pos.x += spread * Random.value - spread / 2;
                    pos.y += spread * Random.value - spread / 2;
                    GameObject go = Instantiate(drop);
                    go.transform.position = pos;
                }
                Destroy(gameObject);
            }
        }
        get
        {
            return health;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //slowly linear interpolate. takes about 3 seconds to return to white
        sr.color = Color.Lerp (sr.color,Color.white,Time.deltaTime/0.2f);
    }
    
    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }


}
