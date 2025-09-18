using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<GameObject> enemies = new List<GameObject>();
    public float spawnInterval = 1f;
    public int autoSpawnCount = 3;

    void Start()
    {
        StartCoroutine(AutoSpawnEnemies());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnMultipleEnemies(100);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ClearEnemies();
        }
    }

    void SpawnEnemy()
    {
   

        GameObject enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
        enemies.Add(enemy);
    }

    void SpawnMultipleEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy();
        }
    }

    void ClearEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear();
    }

    IEnumerator AutoSpawnEnemies()
    {
        while (true)
        {
            SpawnMultipleEnemies(autoSpawnCount);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
