using UnityEngine;

public class Wing : MonoBehaviour
{
    public WeaponsAndItems weaponsAndItems;
    public PlayerController playerController;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    private void Update()
    {
        UpdatePlayerSpeed();
    }

    private void UpdatePlayerSpeed()
    {
        switch (weaponsAndItems.WingsLevel)
        {
            case 1:
                playerController.moveSpeed = 6;
                break;
            case 2:
                playerController.moveSpeed = 8;
                break;
            case 3:
                playerController.moveSpeed = 10;
                break;
            default:
                playerController.moveSpeed = 6;
                break;
        }
    }
}
