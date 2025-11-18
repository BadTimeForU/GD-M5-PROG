using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerPrefab; 
    public float spawnRange = 5f;   

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            SpawnTower();
        }
    }




    void SpawnTower()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            0f,
            Random.Range(-spawnRange, spawnRange)
        );

        Instantiate(towerPrefab, randomPosition, Quaternion.identity);
    }
}
