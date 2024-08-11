using UnityEngine;

[CreateAssetMenu(fileName = "PlayersItems", menuName = "Scriptable_Objects/PlayersItems")]
public class PlayersItem : ScriptableObject
{
    [Header("<---------- Players Current Item list ---------->")]

    [Space(5)]
    [Header("<--- Weapon List --->")]

    [Space(5)]
    [Header("Blade")]
    public bool isBladeEquipped = true;

    [Space(5)]
    [Header("Garlic")]
    public bool isGarlicEquipped = false;

    [Space(5)]
    [Header("Fireball")]
    public bool isFireballEquipped = false;

    [Space(5)]
    [Header("Queen Book")]
    public bool isQuennBookEquipped = false;

    [Space(10)]
    [Header("<--- Item List --->")]

    [Space(5)]
    [Header("Magnet")]
    public bool isMagnetEquipped = false;

    [Space(5)]
    [Header("Max Healh")]
    public bool isMaxHealhEquipped = false;

    [Space(5)]
    [Header("Item Speed Book")]
    public bool isItemSpeedBookEquipped = false;

    [Space(5)]
    [Header("Wing")]
    public bool isWingEquipped = false;

    public void ResetAllEquipments()
    {
        isBladeEquipped = true;
        isGarlicEquipped = false;
        isFireballEquipped = false;
        isQuennBookEquipped = false;
        isMagnetEquipped = false;
        isMaxHealhEquipped = false;
        isItemSpeedBookEquipped = false;
        isWingEquipped = false;
    }

}
