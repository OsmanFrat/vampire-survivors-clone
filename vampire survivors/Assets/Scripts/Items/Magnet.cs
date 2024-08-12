using UnityEngine;

public class Magnet : MonoBehaviour
{
    public WeaponsAndItems weaponsAndItems;

    public CircleCollider2D pickUpRangeCollider;

    private void Start()
    {
        GameObject pickUpRange = GameObject.Find("PickUpRange");
        pickUpRangeCollider = pickUpRange.GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        UpdatePickUpRange();
    }

    private void UpdatePickUpRange()
    {
        switch (weaponsAndItems.MagnetLevel)
        {
            case 1:
                pickUpRangeCollider.radius = 3f;
                break;
            case 2:
                pickUpRangeCollider.radius = 4f;
                break;
            case 3:
                pickUpRangeCollider.radius = 5f;
                break;
            default:
                pickUpRangeCollider.radius = 3f;
                break;
        }
    }
}
