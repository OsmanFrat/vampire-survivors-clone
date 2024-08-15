using System.Collections;
using UnityEngine;

public class SpawnHamburger : MonoBehaviour
{
    public GameObject hamburgerPrefab;
    public Vector2 rectangleSize = new Vector2(10f, 5f);
    public float spawnInterval = 60f;

    private void Start()
    {
        StartCoroutine(SpawnHamburgersRoutine());
    }

    private IEnumerator SpawnHamburgersRoutine()
    {
        while (true)
        {
            SpawnHamburgers();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnHamburgers()
    {
        Vector2 spawnPosition = RandomInsideRectangle(rectangleSize);
        Instantiate(hamburgerPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector2 RandomInsideRectangle(Vector2 size)
    {
        float x = Random.Range(-size.x / 2, size.x / 2);
        float y = Random.Range(-size.y / 2, size.y / 2);
        return new Vector2(x, y) + (Vector2)transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, new Vector3(rectangleSize.x, rectangleSize.y, 0f));
    }
}
