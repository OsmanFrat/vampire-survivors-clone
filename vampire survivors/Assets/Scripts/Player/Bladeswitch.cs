using UnityEngine;

public class Bladeswitch : MonoBehaviour
{
    [SerializeField] private GameObject leftBlade;
    [SerializeField] private GameObject rightBlade;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (!gameManager.gamePaused)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                print("left input!");

                leftBlade.SetActive(true);
                rightBlade.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                print("right input!");

                leftBlade.SetActive(false);
                rightBlade.SetActive(true);
            }
        }
    }
}


