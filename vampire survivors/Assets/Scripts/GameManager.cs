using UnityEngine;
using TMPro;

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

    private void Start()
    {
        Time.timeScale = 1f;
        levelUpPanel.SetActive(false);
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        Timer();

        killCountText.text = killCount.ToString();

        if(levelSystem.playerLeveledUP)
        {
            levelUpPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (player.playerHealth <= 0)
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }

        if (player.playerHealth > 0)
        {
            if (!gamePaused && Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
            else if (gamePaused && Input.GetKeyDown(KeyCode.Escape))
            {
                UnPauseGame();
            }
        }

    }

    public void Timer()
    {
        elapsedTime += Time.deltaTime;  

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);  
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);  

        string timeFormatted = string.Format("{00:00}:{01:00}", minutes, seconds);
        timerText.text = timeFormatted;
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        gamePaused = true;
    }

    private void UnPauseGame()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        gamePaused = false;
    }


    public void PauseGameButton()
    {
        if (player.playerHealth > 0)
        {
            if (!gamePaused)
            {
                PauseGame();
            }
            else if (gamePaused)
            {
                UnPauseGame();
            }
        }
    }
}
