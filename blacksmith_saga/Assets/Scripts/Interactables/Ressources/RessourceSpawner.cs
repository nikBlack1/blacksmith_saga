using UnityEngine;
using Random = UnityEngine.Random;

public class RessourceSpawner : MonoBehaviour
{
    // --------------------------------------
    // ---- Object variables ----------------
    // -------------------------------------- 
    [SerializeField] private int minValue;
    [SerializeField] private int maxValue;
    [SerializeField] private float spread = 2f;
    
    // --------------------------------------
    // ---- Reference variables -------------
    // --------------------------------------
    [SerializeField] private GameObject ressource;
    // -------------------------------------- 
    
    void Start()
    {
        SpawnRessource();
    }

    void SpawnRessource()
    {
        if(minValue <= maxValue)
        {
            int value = Random.Range(minValue, maxValue);

            for (int index = 0; index <= value; index++)
            {
                GameObject gameObject = Instantiate(ressource);
                RandomlyPlaceRessources(gameObject);
            }
        }
    }
    
    public void RandomlyPlaceRessources(GameObject go)
    {
        go.transform.position = transform.position;

        Vector3 pos = go.transform.position;
        pos.x += spread * Random.value - spread / 2;
        pos.y += spread * Random.value - spread / 2;
        
        go.transform.position = pos;
    }
}
