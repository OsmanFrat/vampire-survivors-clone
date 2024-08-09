using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PickUpItem : MonoBehaviour
{
    private Vector2 lastInputDirection;

    void Update()
    {
        // testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Time.timeScale = 1f;
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<FollowPlayer>(out FollowPlayer itemComponent))
        {
            if (!itemComponent.startFollow)
            {
                itemComponent.startFollow = true;
            }

        }
    }
}
