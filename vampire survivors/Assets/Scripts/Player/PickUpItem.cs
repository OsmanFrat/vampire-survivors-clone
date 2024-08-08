using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Vector2 lastInputDirection;

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (input != Vector2.zero)
        {
            lastInputDirection = input.normalized;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
