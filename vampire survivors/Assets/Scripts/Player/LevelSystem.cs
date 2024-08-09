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

    private void Start()
    {
        
    }

    public void ExperienceController()
    {
        levelText.text = "LVL: " + level.ToString();
        xpProgressBar.fillAmount = (currentXp / targetXp);

        if (currentXp >= targetXp)
        {
            playerLeveledUP = true;
            currentXp = currentXp - targetXp;
            level++;
            targetXp += 50;
            ExperienceController();
        }
    }
}
