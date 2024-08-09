using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHealth, maxPlayerhealth = 30f;

    [SerializeField] private PlayerHealthbar playerHealthbar;
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
        enemySpawner.SetActive(true);
        playerHealthbar.UpdateHealthBar(playerHealth, maxPlayerhealth);
    }

    private void Update()
    {
        playerHealthbar.UpdateHealthBar(playerHealth, maxPlayerhealth);  
    }

    public void TakeDamage(float damageAmount)
    {
        playerHealth -= damageAmount;
        playerHealthbar.UpdateHealthBar(playerHealth, maxPlayerhealth);

        if (playerHealth <= 0)
        {
            // oyuncu oldugunde yapilmasi gereken degisiklikler
            rb.velocity = new Vector2(0, 0);
            playerController.enabled = false;
            enemySpawner.SetActive(false);

            Debug.Log("Player died!");
        }
    }
}
