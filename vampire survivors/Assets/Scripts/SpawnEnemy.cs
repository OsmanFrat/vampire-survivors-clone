using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public CircleCollider2D circleCollider; 
    public int numberOfEnemies = 5;
    public float spawnInterval = 0.5f;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    void SpawnEnemies()
    {

        float angle = Random.Range(0f, 360f);

        float radian = angle * Mathf.Deg2Rad;


        Vector2 spawnPosition = new Vector2(
            circleCollider.bounds.center.x + circleCollider.radius * Mathf.Cos(radian),
            circleCollider.bounds.center.y + circleCollider.radius * Mathf.Sin(radian)
        );


        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        
    }
}
