using UnityEngine;

public class CollideWithItem : MonoBehaviour
{
    [SerializeField] private LevelSystem levelSystem;
    [SerializeField] private Player player;

    public bool playEatingSfx = false;
    public bool playExpSfx = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            levelSystem.currentXp += 10;
            levelSystem.ExperienceController();

            playExpSfx = true;

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Hamburger"))
        {

            if (player.playerHealth > 0)
            {
                player.playerHealth += 30f;

                if (player.playerHealth > player.maxPlayerhealth)
                {
                    player.playerHealth = player.maxPlayerhealth;
                }
            }

            playEatingSfx = true;

            Destroy(collision.gameObject);
        }
    }

}