using UnityEngine;

public class Bladeswitch : MonoBehaviour
{
    [SerializeField] private GameObject leftBlade;
    [SerializeField] private GameObject rightBlade;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            leftBlade.SetActive(true);
            rightBlade.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            leftBlade.SetActive(false);
            rightBlade.SetActive(true);
        }
    }
}


