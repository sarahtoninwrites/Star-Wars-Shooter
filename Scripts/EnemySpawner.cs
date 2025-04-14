using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 spawnAreaMin; // bottom-left corner
    public Vector2 spawnAreaMax; // top-right corner
    public float spawnInterval = 3f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
    void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Vector3 center = (Vector3)(spawnAreaMin + spawnAreaMax) / 2;
    Vector3 size = (Vector3)(spawnAreaMax - spawnAreaMin);
    Gizmos.DrawWireCube(center, size);
}

}
