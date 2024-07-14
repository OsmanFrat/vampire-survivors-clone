using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 1.0f;
    [SerializeField] private GameObject player;

    [SerializeField] float enemyHealth, maxEnemyHealth = 1f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        enemyHealth = maxEnemyHealth;
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
