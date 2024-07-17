using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public int playerLvl = 1;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI killCountText;

    private float elapsedTime;
    public int killCount = 0;

    private void Update()
    {
        Timer();

        killCountText.text = killCount.ToString();
    }


    public void Timer()
    {
        elapsedTime += Time.deltaTime;  

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);  
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);  

        // Format the time as MM:SS
        string timeFormatted = string.Format("{00:00}:{01:00}", minutes, seconds);
        timerText.text = timeFormatted;
    }
}
