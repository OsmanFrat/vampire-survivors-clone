using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Transform playerTransform;

    private void FixedUpdate()
    {
        transform.position = playerTransform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.CompareTag("Exp") || collision.CompareTag("Hamburger"))
        {
            Debug.Log("Collided with Exp!");
            collision.gameObject.TryGetComponent<FollowPlayer>(out FollowPlayer followPlayer);
            followPlayer.startFollow = true;
        }
    }

}
