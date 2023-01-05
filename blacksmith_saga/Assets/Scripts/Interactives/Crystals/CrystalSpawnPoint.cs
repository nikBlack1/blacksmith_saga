using UnityEngine;
using Random = UnityEngine.Random;

public class CrystalSpawnPoint : MonoBehaviour
{
    // --------------------------------------
    // ---- Object variables ----------------
    // -------------------------------------- 
    [SerializeField] private int crystalsCountPerSpawn;
    [SerializeField] private float spread = 2f;
    public int restCrystals;
    
    // --------------------------------------
    // ---- Reference variables -------------
    // --------------------------------------
    [SerializeField] private GameObject crystal;
    // [SerializeField] private int respawnTime = 60;
    // -------------------------------------- 
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnCrystals();
    }

    private void Update()
    {
        if (restCrystals <= 0)
        {
            SpawnCrystals();
        }
    }

    void SpawnCrystals()
    {
        while (crystalsCountPerSpawn > 0)
        {
            crystalsCountPerSpawn  -= 1;
            restCrystals += 1;
            GameObject go = Instantiate(crystal);
            RandomlyPlaceCrystal(go);
        }
    }
    
    public void RandomlyPlaceCrystal(GameObject go)
    {
        go.transform.position = transform.position;

        Vector3 pos = go.transform.position;
        pos.x += spread * Random.value - spread / 2;
        pos.y += spread * Random.value - spread / 2;
        
        go.transform.position = pos;
    }
}
