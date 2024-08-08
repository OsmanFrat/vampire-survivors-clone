using UnityEngine;

public class CollideWithItem : MonoBehaviour
{
    [SerializeField] private LevelSystem levelSystem;
    [SerializeField] private Player player;
    [SerializeField] private AudioClip eatingSoundEffect;
    [SerializeField] private AudioSource _source;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blue Exp"))
        {
            levelSystem.currentXp += 10;
            levelSystem.ExperienceController();

            Debug.Log("Blue Exp collected!");

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

            Debug.Log("Hamburger eaten!");

            _source.PlayOneShot(eatingSoundEffect);

            Destroy(collision.gameObject);
        }
    }
}