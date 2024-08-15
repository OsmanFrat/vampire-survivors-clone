using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdatePlayerStatsOnUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerLevelText;
    [SerializeField] TextMeshProUGUI playerMaxHealhText;
    [SerializeField] TextMeshProUGUI playerSpeedText;
    [SerializeField] TextMeshProUGUI magnetText;
    [SerializeField] TextMeshProUGUI hamburgerSpawnRateText;

    [SerializeField] GameManager gameManager;
    [SerializeField] Player player;
    [SerializeField] PlayerController playerController;
    [SerializeField] SpawnHamburger spawnHamburger;
    [SerializeField] CircleCollider2D pickUpRangeCollider;

    [SerializeField] float pickUpRadius;

    private void Update()
    {
        UpdatePlayerStatsInUI();
    }

    private void UpdatePlayerStatsInUI()
    {
        playerLevelText.text = "Player Level: " + gameManager.playerLvl.ToString();
        playerMaxHealhText.text = "Player Max Healh: " + player.maxPlayerhealth.ToString();
        playerSpeedText.text = "Player Speed: " + playerController.moveSpeed.ToString();

        pickUpRadius = pickUpRangeCollider.radius;
        magnetText.text = "Magnet: " + pickUpRadius.ToString();

        hamburgerSpawnRateText.text = "Burger Spawn Rate: " + spawnHamburger.spawnInterval.ToString() + "s";
    }
}
