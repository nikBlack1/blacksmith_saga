using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int maxAmount;
    [SerializeField] private float spawnIntervalMin = 10f;
    [SerializeField] private float spawnIntervalMax = 60f;

    Vector3 spawnerPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnerPosition = transform.position;
        StartCoroutine(spawnEnemy(enemyPrefab));
    }

    private IEnumerator spawnEnemy(GameObject _enemy)
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < maxAmount)
        {
            GameObject newEnemy = Instantiate(_enemy, new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0) + spawnerPosition, Quaternion.identity);
        }

        yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));
        StartCoroutine(spawnEnemy(_enemy));
    }
}
