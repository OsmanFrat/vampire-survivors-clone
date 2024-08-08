using UnityEngine;

public class HamburgerSpawner : MonoBehaviour
{
    public GameObject hamburgerPrefab;
    public Transform player;
    public BoxCollider2D spawnArea;
    public float spawnInterval = 60f;
    public Color gizmoColor = Color.yellow;

    void Start()
    {
        InvokeRepeating("SpawnHamburgerAtRandomPoint", 0f, spawnInterval);
    }

    void SpawnHamburgerAtRandomPoint()
    {
        if (spawnArea != null)
        {
            Vector2 randomPoint = new Vector2(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y)
            );

            Vector3 spawnPosition = new Vector3(randomPoint.x, randomPoint.y, player.position.z);
            Instantiate(hamburgerPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        if (spawnArea != null)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireCube(spawnArea.bounds.center, spawnArea.bounds.size);
        }
    }
}
