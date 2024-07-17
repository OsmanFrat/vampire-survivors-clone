using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 1.0f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameManager gameManager;
    public GameObject expPrefab;
    public float expSpawnRate;

    [SerializeField] float enemyHealth, maxEnemyHealth = 1f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        enemyHealth = maxEnemyHealth;
        expSpawnRate = Random.Range(0f, 0.7f);
    }
    // follow the player
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;

        if (enemyHealth <= 0)
        {
            if (expSpawnRate <= 0.5f)
            {
                // Drop the exp item
                Instantiate(expPrefab, transform.position, Quaternion.identity);
            }
            gameManager.killCount++;
            // kill the enemy
            Destroy(gameObject);
            Debug.Log("Enemy killed!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Oyuncuya zarar ver
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
        }
    }
}
