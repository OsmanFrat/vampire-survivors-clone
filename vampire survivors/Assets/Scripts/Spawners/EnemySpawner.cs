using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Spawnlanacak düşman prefabı
    public float radius = 5f; // Çemberin yarıçapı
    public float spawnInterval = 0.5f; // Spawnlama aralığı

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        Vector2 localSpawnPosition = RandomOnCircleEdge(radius);
        Vector3 worldSpawnPosition = transform.TransformPoint(localSpawnPosition);
        Instantiate(enemyPrefab, worldSpawnPosition, Quaternion.identity);
    }

    private Vector2 RandomOnCircleEdge(float radius)
    {
        // Çemberin kenarında rastgele bir açı oluştur
        float angle = Random.Range(0f, Mathf.PI * 2);
        // Açı ve yarıçap kullanarak spawn noktasını hesapla
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
    }

    private void OnDrawGizmos()
    {
        // Çemberin çizilmesi
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
