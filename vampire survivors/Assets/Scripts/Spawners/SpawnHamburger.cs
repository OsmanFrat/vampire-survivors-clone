using UnityEngine;

public class SpawnHamburger : MonoBehaviour
{
    public GameObject hamburgerPrefab; // Spawnlanacak hamburger prefabı
    public Vector2 rectangleSize = new Vector2(10f, 5f); // Dikdörtgenin boyutları (genişlik, yükseklik)
    public float spawnInterval = 60f; // Spawnlama aralığı

    private void Start()
    {
        InvokeRepeating("SpawnHamburgers", 0f, spawnInterval);
    }

    private void SpawnHamburgers()
    {
        Vector2 spawnPosition = RandomInsideRectangle(rectangleSize);
        Instantiate(hamburgerPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector2 RandomInsideRectangle(Vector2 size)
    {
        // Dikdörtgenin içinde rastgele bir nokta üret
        float x = Random.Range(-size.x / 2, size.x / 2);
        float y = Random.Range(-size.y / 2, size.y / 2);
        return new Vector2(x, y) + (Vector2)transform.position;
    }

    private void OnDrawGizmos()
    {
        // Dikdörtgenin çizilmesi
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, new Vector3(rectangleSize.x, rectangleSize.y, 0f));
    }
}
