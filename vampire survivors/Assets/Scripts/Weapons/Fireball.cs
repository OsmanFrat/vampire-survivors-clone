using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float spawnInterval = 3f;
    public float projectileSpeed = 7f;
    public Vector2 offset = new Vector2(0.3f, 0);

    private Vector2 lastInputDirection;

    void Start()
    {
        lastInputDirection = Vector2.right;
        StartCoroutine(SpawnProjectiles());
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (input != Vector2.zero)
        {
            lastInputDirection = input.normalized;
        }

        Vector3 offsetPosition = new Vector3(lastInputDirection.x * offset.x, lastInputDirection.y * offset.y, 0);
        transform.localPosition = offsetPosition;
    }

    IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (lastInputDirection != Vector2.zero)
            {
                Vector3 spawnPosition = transform.position;
                float zRotation = Mathf.Atan2(lastInputDirection.y, lastInputDirection.x) * Mathf.Rad2Deg;

                // Adjust angles based on the direction
                SpawnProjectile(spawnPosition, zRotation - 10f);
                SpawnProjectile(spawnPosition, zRotation);
                SpawnProjectile(spawnPosition, zRotation + 10f);
            }
        }
    }

    void SpawnProjectile(Vector3 position, float angle)
    {
        GameObject projectile = Instantiate(fireballPrefab, position, Quaternion.Euler(0, 0, angle));
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.right;
        rb.velocity = direction * projectileSpeed;

        Destroy(projectile, 5f);
    }
}
