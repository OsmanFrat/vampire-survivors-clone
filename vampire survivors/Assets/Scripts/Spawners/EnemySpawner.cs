using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Spawnlanacak düşman prefabı
    public Vector2 rectangleSize = new Vector2(10f, 5f); // Dikdörtgenin boyutu (en x boy)
    public float spawnInterval = 0.5f; // Spawnlama aralığı

    private void Start()
    {
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        Vector2 localSpawnPosition = RandomOnRectangleEdge(rectangleSize);
        Vector3 worldSpawnPosition = transform.TransformPoint(localSpawnPosition);
        Instantiate(enemyPrefab, worldSpawnPosition, Quaternion.identity);
    }

    private Vector2 RandomOnRectangleEdge(Vector2 size)
    {
        // Dikdörtgenin kenarları boyunca rastgele bir konum seç
        float perimeter = 2 * (size.x + size.y);
        float randomPoint = Random.Range(0f, perimeter);

        if (randomPoint < size.x) // Üst kenar
        {
            return new Vector2(randomPoint - size.x / 2, size.y / 2);
        }
        else if (randomPoint < size.x + size.y) // Sağ kenar
        {
            return new Vector2(size.x / 2, (randomPoint - size.x) - size.y / 2);
        }
        else if (randomPoint < 2 * size.x + size.y) // Alt kenar
        {
            return new Vector2((randomPoint - size.x - size.y) - size.x / 2, -size.y / 2);
        }
        else // Sol kenar
        {
            return new Vector2(-size.x / 2, (randomPoint - 2 * size.x - size.y) + size.y / 2);
        }
    }

    private void OnDrawGizmos()
    {
        // Dikdörtgenin çizilmesi
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(rectangleSize.x, rectangleSize.y, 0f));
    }
}
