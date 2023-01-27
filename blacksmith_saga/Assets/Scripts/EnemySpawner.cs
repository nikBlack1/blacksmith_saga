using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int maxAmount;
    [SerializeField] private float spawnInterval = 60f;

    Vector3 spawnerPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnerPosition = transform.position;
        StartCoroutine(spawnEnemy(spawnInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float _interval, GameObject _enemy)
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < maxAmount)
        {
            GameObject newEnemy = Instantiate(_enemy, new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.6f, 0.6f), 0) + spawnerPosition, Quaternion.identity);
        }

        yield return new WaitForSeconds(_interval);
        StartCoroutine(spawnEnemy(_interval, _enemy));
    }
}
