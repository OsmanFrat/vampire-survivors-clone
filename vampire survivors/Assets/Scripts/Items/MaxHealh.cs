using UnityEngine;

public class MaxHealh : MonoBehaviour
{
    public WeaponsAndItems weaponsAndItems;
    public Player playerScript;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }
    private void Update()
    {
        UpdatePlayerMaxHealh();
    }

    private void UpdatePlayerMaxHealh()
    {
        switch (weaponsAndItems.MaxHealthLevel)
        {
            case 1:
                playerScript.maxPlayerhealth = 40;
                break;
            case 2:
                playerScript.maxPlayerhealth = 50;
                break;
            case 3:
                playerScript.maxPlayerhealth = 60;
                break;
            default:
                playerScript.maxPlayerhealth = 40;
                break;
        }
    }
}
