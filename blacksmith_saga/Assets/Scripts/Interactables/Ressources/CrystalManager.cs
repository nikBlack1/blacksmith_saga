using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrystalManager : MonoBehaviour
{
    
    // --------------------------------------
    // ---- Object variables ----------------
    // -------------------------------------- 
    [SerializeField] private int crystalsCountPerSpawn;
    [SerializeField] private float spread = 2f;
    public int restCrystals;
    public static CrystalManager Instance;


    // -------------------------------------- 

    
    
    // --------------------------------------
    // ---- Reference variables -------------
    // --------------------------------------
    [SerializeField] private GameObject crystal;
    // [SerializeField] private int respawnTime = 60;
    // -------------------------------------- 

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        // restCrystals = crystalsCountPerSpawn;

        SpawnCrystals();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (restCrystals <= 0)
        {
            SpawnCrystals();
        }
    }

    
    void SpawnCrystals()
    {
        crystalsCountPerSpawn = 5;
        while (crystalsCountPerSpawn > 0)
        {
            crystalsCountPerSpawn  -= 1;
            restCrystals += 1;
            GameObject go = Instantiate(crystal);
            RandomlyPlaceCrystal(go);
        }
    }

    public void SubstractCrystal()
    {
        restCrystals -= 1;
    }

    public void RandomlyPlaceCrystal(GameObject go)
    {
        go.transform.position = new Vector3(0, 0, 0);

        Vector3 pos = go.transform.position;
        pos.x += spread * Random.value - spread / 2;
        pos.y += spread * Random.value - spread / 2;
        
        go.transform.position = pos;
    }
}
