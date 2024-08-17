using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItemSelect : MonoBehaviour
{
    [SerializeField] WeaponsAndItems weaponsAndItems;
    List<string> allWeaponsAndItems = new List<string> { "Blade", "Garlic", "FireballShooter", "QueenBook", "MaxHealth", "Magnet", "Wing", "FastBurger" };
    List<string> selectedItems = new List<string>();

    [SerializeField] Button[] itemButtons;

    [SerializeField] private Sprite bladeSprite;
    [SerializeField] private Sprite garlicSprite;
    [SerializeField] private Sprite fireballShooterSprite;
    [SerializeField] private Sprite queenBookSprite;
    [SerializeField] private Sprite maxHealthSprite;
    [SerializeField] private Sprite magnetSprite;
    [SerializeField] private Sprite wingSprite;
    [SerializeField] private Sprite fastBurgerSprite;

    private Dictionary<string, Sprite> itemSprites;
    private Dictionary<string, Button> itemButtonsMap;

    public bool isItemSelected = false;

    void Start()
    {
        itemSprites = new Dictionary<string, Sprite>
        {
            { "Blade", bladeSprite },
            { "Garlic", garlicSprite },
            { "FireballShooter", fireballShooterSprite },
            { "QueenBook", queenBookSprite },
            { "MaxHealth", maxHealthSprite },
            { "Magnet", magnetSprite },
            { "Wing", wingSprite },
            { "FastBurger", fastBurgerSprite }
        };

        SelectRandomItems();
        UpdateButtonImages();
        AssignButtonEvents();
    }

    private void Update()
    {
        // Debug log for current allWeaponsAndItems list items
        if (Input.GetKeyDown(KeyCode.I))
        {
            foreach (string item in allWeaponsAndItems)
            {
                Debug.Log(item);
            }
        }
    }

    public void SelectRandomItems()
    {
        selectedItems.Clear();

        while (selectedItems.Count < 3)
        {
            string randomItem = allWeaponsAndItems[Random.Range(0, allWeaponsAndItems.Count)];

            if (!selectedItems.Contains(randomItem))
            {
                selectedItems.Add(randomItem);
            }
        }

        foreach (string item in selectedItems)
        {
            Debug.Log(item);
        }
    }

    public void UpdateButtonImages()
    {
        itemButtonsMap = new Dictionary<string, Button>();

        for (int i = 0; i < selectedItems.Count; i++)
        {
            string selectedItem = selectedItems[i];

            if (i < itemButtons.Length)
            {
                Image buttonImage = itemButtons[i].GetComponent<Image>();

                if (itemSprites.ContainsKey(selectedItem))
                {
                    buttonImage.sprite = itemSprites[selectedItem];
                    itemButtonsMap[selectedItem] = itemButtons[i];
                }
            }
        }
    }

    public void AssignButtonEvents()
    {
        foreach (var item in selectedItems)
        {
            if (itemButtonsMap.ContainsKey(item))
            {
                itemButtonsMap[item].onClick.AddListener(() => OnItemButtonClicked(item));
            }
        }
    }

    public void OnItemButtonClicked(string itemName)
    {
        Debug.Log(itemName + " butonuna basıldı!");

        switch (itemName)
        {
            case "Blade":
                if (!weaponsAndItems.isBladeEquipped)
                {
                    weaponsAndItems.isBladeEquipped = true;
                }
                else if (weaponsAndItems.isBladeEquipped && weaponsAndItems.BladeLevel < 3)
                {
                    weaponsAndItems.BladeLevel++;
                }
                else if (weaponsAndItems.isBladeEquipped && weaponsAndItems.BladeLevel >= 3)
                {
                    Debug.Log(itemName + " removed from allWeaponsAndItems!");
                    //allWeaponsAndItems.Remove("Blade");
                }
                break;

            case "Garlic":
                if (!weaponsAndItems.isGarlicEquipped)
                {
                    weaponsAndItems.isGarlicEquipped = true;
                }
                else if (weaponsAndItems.isGarlicEquipped && weaponsAndItems.GarlicLevel < 3)
                {
                    weaponsAndItems.GarlicLevel++;
                }
                else if (weaponsAndItems.isGarlicEquipped && weaponsAndItems.GarlicLevel >= 3)
                {
                    Debug.Log(itemName + " removed from allWeaponsAndItems!");
                    //allWeaponsAndItems.Remove("Garlic");
                }
                break;

            case "FireballShooter":
                if (!weaponsAndItems.isFireballEquipped)
                {
                    weaponsAndItems.isFireballEquipped = true;
                }
                else if (weaponsAndItems.isFireballEquipped && weaponsAndItems.FireballLevel < 3)
                {
                    weaponsAndItems.FireballLevel++;
                }
                else if (weaponsAndItems.isFireballEquipped && weaponsAndItems.FireballLevel >= 3)
                {
                    Debug.Log(itemName + " removed from allWeaponsAndItems!");
                    //allWeaponsAndItems.Remove("FireballShooter");
                }
                break;

            case "QueenBook":
                if (!weaponsAndItems.isQueenBookEquipped)
                {
                    weaponsAndItems.isQueenBookEquipped = true;
                }
                else if (weaponsAndItems.isQueenBookEquipped && weaponsAndItems.QueenBookLevel < 3)
                {
                    weaponsAndItems.QueenBookLevel++;
                }
                else if (weaponsAndItems.isQueenBookEquipped && weaponsAndItems.QueenBookLevel >= 3)
                {
                    Debug.Log(itemName + " removed from allWeaponsAndItems!");
                    //allWeaponsAndItems.Remove("QueenBook");
                }
                break;

            case "MaxHealth":
                if (!weaponsAndItems.isMaxHealhEquipped)
                {
                    weaponsAndItems.isMaxHealhEquipped = true;
                }
                else if (weaponsAndItems.isMaxHealhEquipped && weaponsAndItems.MaxHealthLevel < 3)
                {
                    weaponsAndItems.MaxHealthLevel++;
                }
                else if (weaponsAndItems.isMagnetEquipped && weaponsAndItems.MaxHealthLevel >= 3)
                {
                    Debug.Log(itemName + " removed from allWeaponsAndItems!");
                    //allWeaponsAndItems.Remove("MaxHealth");
                }
                break;

            case "Magnet":
                if (!weaponsAndItems.isMagnetEquipped)
                {
                    weaponsAndItems.isMagnetEquipped = true;
                }
                else if (weaponsAndItems.isMagnetEquipped && weaponsAndItems.MagnetLevel < 3)
                {
                    weaponsAndItems.MagnetLevel++;
                }
                else if (weaponsAndItems.isMagnetEquipped && weaponsAndItems.MagnetLevel >= 3)
                {
                    Debug.Log(itemName + " removed from allWeaponsAndItems!");
                    //allWeaponsAndItems.Remove("Magnet");
                }
                break;

            case "Wing":
                if (!weaponsAndItems.isWingsEquipped)
                {
                    weaponsAndItems.isWingsEquipped = true;
                }
                else if (weaponsAndItems.isWingsEquipped && weaponsAndItems.WingsLevel < 3)
                {
                    weaponsAndItems.WingsLevel++;
                }
                else if (weaponsAndItems.isWingsEquipped && weaponsAndItems.WingsLevel >= 3)
                {
                    Debug.Log(itemName + " removed from allWeaponsAndItems!");
                    //allWeaponsAndItems.Remove("Wing");
                }
                break;

            case "FastBurger":
                if (!weaponsAndItems.isFastHamburgerEquipped)
                {
                    weaponsAndItems.isFastHamburgerEquipped = true;
                }
                else if (weaponsAndItems.isFastHamburgerEquipped && weaponsAndItems.FastHamburgerLevel < 3)
                {
                    weaponsAndItems.FastHamburgerLevel++;
                }
                else if (weaponsAndItems.isFastHamburgerEquipped && weaponsAndItems.FastHamburgerLevel >= 3)
                {
                    Debug.Log(itemName + " removed from allWeaponsAndItems!");
                    //allWeaponsAndItems.Remove("FastBurger");
                }
                break;
        }

        isItemSelected = true;
    }
}
