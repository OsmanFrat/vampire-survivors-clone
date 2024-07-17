using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHealth, maxPlayerhealth = 30f;

    [SerializeField] private PlayerHealthbar playerHealthbar;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject rightBlade;
    [SerializeField] private GameObject leftBlade;
    [SerializeField] private Bladeswitch bladeswitch;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        playerHealthbar = GetComponentInChildren<PlayerHealthbar>();
    }

    private void Start()
    {
        playerHealth = maxPlayerhealth;

        spriteRenderer.enabled = true;
        bladeswitch.enabled = true;
        bladeswitch.enabled = true;
        rightBlade.SetActive(false);
        leftBlade.SetActive(true);
        enemySpawner.SetActive(true);

        playerHealthbar.UpdateHealthBar(playerHealth, maxPlayerhealth);
    }

    public void TakeDamage(float damageAmount)
    {
        playerHealth -= damageAmount;
        playerHealthbar.UpdateHealthBar(playerHealth, maxPlayerhealth);

        if (playerHealth <= 0)
        {
            // deactivating some objects and components
            rb.velocity = new Vector2(0, 0);
            playerController.enabled = false;
            bladeswitch.enabled = false;
            spriteRenderer.enabled = false;
            rightBlade.SetActive(false);
            leftBlade.SetActive(false);
            enemySpawner.SetActive(false);

            Debug.Log("Player died!");
        }
    }

    


}
