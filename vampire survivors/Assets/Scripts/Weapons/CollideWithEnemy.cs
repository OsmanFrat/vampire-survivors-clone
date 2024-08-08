using UnityEngine;

public class CollideWithEnemy : MonoBehaviour
{

    public bool onTriggerEnter = false;
    public bool onTriggerStay = false;

    public float weaponDamage = 0.2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent) && onTriggerEnter)
        {
            enemyComponent.TakeDamage(weaponDamage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent) && onTriggerStay)
        {
            enemyComponent.TakeDamage(weaponDamage);
        }
    }
}
