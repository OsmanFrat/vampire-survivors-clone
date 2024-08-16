using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItemSelect : MonoBehaviour
{
    List<string> allWeaponsAndItems = new List<string> { "Blade", "Garlic", "FireballShooter", "QueenBook", "MaxHealth", "Magnet", "Wing", "FastBurger" };
    List<string> selectedItems = new List<string>();

    void Start()
    {
        SelectRandomItems();
    }

    void SelectRandomItems()
    {
        selectedItems.Clear(); // Önceki seçimleri temizler

        while (selectedItems.Count < 3)
        {
            string randomItem = allWeaponsAndItems[Random.Range(0, allWeaponsAndItems.Count)];

            if (!selectedItems.Contains(randomItem))
            {
                selectedItems.Add(randomItem);
            }
        }

        // Seçilen öğeleri konsola yazdır
        foreach (string item in selectedItems)
        {
            Debug.Log(item);
        }
    }
}
