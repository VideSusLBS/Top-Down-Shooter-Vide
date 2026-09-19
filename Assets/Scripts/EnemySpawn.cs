using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float minSpawnTime = 1.0f;
    [SerializeField] float maxSpawnTime = 3.0f;

    float spawnDistance = 10f;
    Vector2 screenBoundary;
    Vector2 spawnPos;
    
    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        int spawnSide = Random.Range(0, 4);
        switch (spawnSide)
        {
            case 0:
                spawnPos = new Vector2(Random.Range(-screenBoundary.x, screenBoundary.x), screenBoundary.y + spawnDistance);
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(-screenBoundary.x, screenBoundary.x), -screenBoundary.y - spawnDistance);
                break;
            case 2:
                spawnPos = new Vector2(screenBoundary.x + spawnDistance, Random.Range(-screenBoundary.y, screenBoundary.y));
                break;
            case 3:
                spawnPos = new Vector2(-screenBoundary.x - spawnDistance, Random.Range(-screenBoundary.y, screenBoundary.y));
                break;
        }
        Instantiate(enemyPrefab, spawnPos, transform.rotation);
        Invoke("SpawnEnemy" ,spawnTime);
    }
}
