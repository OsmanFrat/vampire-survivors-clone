using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameManager gameManager; 
    public GameObject expPrefab;
    public float expSpawnRate;
    [SerializeField] float enemyHealth, maxEnemyHealth = 1f;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        enemyHealth = maxEnemyHealth;
        expSpawnRate = Random.Range(0f, 0.7f);
    }

    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;

        if (enemyHealth <= 0)
        {
            if (expSpawnRate <= 0.5f)
            {
                // drop exp
                Instantiate(expPrefab, transform.position, Quaternion.identity);
            }

            gameManager.killCount++;
            // kill the enemy
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Oyuncuya zarar ver
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.TakeDamage(0.2f);
            }
        }
    }
}
