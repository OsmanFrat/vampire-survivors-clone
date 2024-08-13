using UnityEngine;

public class FastBurger : MonoBehaviour
{
    public WeaponsAndItems weaponsAndItems;
    [SerializeField] private SpawnHamburger spawnHamberger;

    private void Start()
    {
        GameObject spawnHambergerObject = GameObject.Find("HamburgerSpawner");
        spawnHamberger = spawnHamberger.GetComponent<SpawnHamburger>();
    }

    private void Update()
    {
        UpdateHamburgerInternal();
    }

    private void UpdateHamburgerInternal()
    {
        switch (weaponsAndItems.FastHamburgerLevel)
        {
            case 1:
                spawnHamberger.spawnInterval = 50;
                break;
            case 2:
                spawnHamberger.spawnInterval = 40;
                break;
            case 3:
                spawnHamberger.spawnInterval = 30;
                break;
            default:
                spawnHamberger.spawnInterval = 50;
                break;
        }
    }
}
