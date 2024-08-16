using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private int level = 1;
    public float currentXp;
    [SerializeField] private float targetXp;
    [SerializeField] private Image xpProgressBar;
    public bool playerLeveledUP = false;

    public bool hasDebugMode = false;

    void Start()
    {
        // hasDebugMode test
        if (hasDebugMode)
        {
            Debug.Log("Debug mode activated! TargetXp = 90000");
            targetXp = 90000f;
        }
        else
        {
            Debug.Log("Normal mode activated! TargetXp += 50.");
            targetXp += 50;
        }
    }

    public void ExperienceController()
    {
        levelText.text = "LVL: " + level.ToString();
        xpProgressBar.fillAmount = (currentXp / targetXp);

        if (currentXp >= targetXp)
        {
            playerLeveledUP = true;
            currentXp -= targetXp;
            level++;

            // Mode check
            if (hasDebugMode)
            {
                Debug.Log("Debug mode activated! TargetXp = 90000");
                targetXp = 90000f;
            }
            else
            {
                Debug.Log("Normal mode activated! TargetXp += 50.");
                targetXp += 50;
            }
        }
    }

    public void LevelUp() // Method to manually level up
    {
        playerLeveledUP = true;
        currentXp = targetXp; // Ensure that XP is enough to level up
        ExperienceController(); // Update the level and UI
    }
}
