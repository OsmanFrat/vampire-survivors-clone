using UnityEngine;
using TMPro;
using UnityEditor.Search;

public class GameManager : MonoBehaviour
{
    public int playerLvl = 1;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI killCountText;

    private float elapsedTime;
    public int killCount = 0;

    [SerializeField] private LevelSystem levelSystem;
    [SerializeField] private Player player;

    public GameObject levelUpPanel;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public bool gamePaused = false;

    public bool playLevelUpSfx = false;
    public bool playGameOverSfx = false;

    public GameObject colorfullBar;

    public WeaponsAndItems weaponsAndItems;

    public GameObject garlicObject;
    public GameObject fireballShooterObject;
    public GameObject queenBookObject;
    public GameObject maxHealthObject;
    public GameObject magnetObject;
    public GameObject wingObject;
    public GameObject fastBurgerObject;

    private void Awake()
    {
        weaponsAndItems.ResetValues();
    }

    private void Start()
    {
        Time.timeScale = 1f;
        colorfullBar.SetActive(false);
        levelUpPanel.SetActive(false);
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);

        garlicObject.SetActive(false);
        fireballShooterObject.SetActive(false);
        queenBookObject.SetActive(false);
        maxHealthObject.SetActive(false);
        magnetObject.SetActive(false);
        wingObject.SetActive(false);
        fastBurgerObject.SetActive(false);
}

    private void Update()
    {
        Timer();

        killCountText.text = killCount.ToString();

        HandleLevelUp();
        HandleGameOver();
        HandlePauseToggle();

        UpdatePlayerCurrentItems();
    }

    private void Timer()
    {
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        string timeFormatted = string.Format("{00:00}:{01:00}", minutes, seconds);
        timerText.text = timeFormatted;
    }

    private void HandleLevelUp()
    {
        if (levelSystem.playerLeveledUP && !levelUpPanel.activeSelf)
        {
            if (!playLevelUpSfx)
            {
                playLevelUpSfx = true;
            }
            colorfullBar.SetActive(true);
            levelUpPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void HandleGameOver()
    {
        if (player.playerHealth <= 0 && !gameOverScreen.activeSelf)
        {
            if (!playGameOverSfx)
            {
                playGameOverSfx = true;
            }

            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }

    private void HandlePauseToggle()
    {
        if (player.playerHealth > 0)
        {
            if (!gamePaused && Input.GetKeyDown(KeyCode.Escape) && !levelUpPanel.activeSelf)
            {
                PauseGame();
            }
            else if (gamePaused && Input.GetKeyDown(KeyCode.Escape))
            {
                UnPauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        gamePaused = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        gamePaused = false;
    }

    public void PauseGameButton()
    {
        if (player.playerHealth > 0 && !levelUpPanel.activeSelf)
        {
            if (!gamePaused)
            {
                PauseGame();
            }
            else
            {
                UnPauseGame();
            }
        }
    }

    public void UpdatePlayerCurrentItems()
    {
        if (weaponsAndItems.isGarlicEquipped)
        {
            garlicObject.SetActive(true);
        }
        if (weaponsAndItems.isFireballEquipped)
        {
            fireballShooterObject.SetActive(true);
        }
        if (weaponsAndItems.isQuennBookEquipped)
        {
            queenBookObject.SetActive(true);
        }
        if (weaponsAndItems.isMaxHealhEquipped)
        {
            maxHealthObject.SetActive(true);
        }
        if (weaponsAndItems.isMagnetEquipped)
        {
            magnetObject.SetActive(true);
        }
        if (weaponsAndItems.isWingsEquipped)
        {
            wingObject.SetActive(true);
        }
        if (weaponsAndItems.isFastHamburgerEquipped)
        {
            fastBurgerObject.SetActive(true);
        }    
    }
}