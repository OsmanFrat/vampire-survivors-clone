using UnityEngine;

[CreateAssetMenu(fileName = "WeaponAndItems", menuName = "Scriptable_Objects/WeaponsAndItems")]
public class WeaponsAndItems : ScriptableObject
{
    [Header("---------- Weapons ----------")]

    [Space(10)]
    [Header("Blade")]
    public int BladeLevel = 1;
    public bool isBladeEquipped = true;

    [Space(10)]
    [Header("Garlic")]
    public int GarlicLevel = 1;
    public bool isGarlicEquipped = false;

    [Space(10)]
    [Header("Fireball")]
    public int FireballLevel = 1;
    public bool isFireballEquipped = false;

    [Space(10)]
    [Header("Queen Book")]
    public int QuennBookLevel = 1;
    public bool isQuennBookEquipped = false;

    [Space(20)]
    [Header("---------- Items ------------")]

    [Space(10)]
    [Header("Magnet")]
    public int MagnetLevel = 1;
    public bool isMagnetEquipped = false;

    [Space(10)]
    [Header("Max Healh")]
    public int MaxHealthLevel = 1;
    public bool isMaxHealhEquipped = false;

    [Space(10)]
    [Header("Item Speed Book")]
    public int ItemSpeedBookLevel = 1;
    public bool isItemSpeedBookEquipped = false;

    [Space(10)]
    [Header("Wings")]
    public int WingsLevel = 1;
    public bool isWingsEquipped = false;

    public void ResetValues()
    {
        GarlicLevel = 1;
        FireballLevel = 1;
        BladeLevel = 1;
        QuennBookLevel = 1;
        MagnetLevel = 1;
        MaxHealthLevel = 1;
        ItemSpeedBookLevel = 1;
        WingsLevel = 1;

        isBladeEquipped = true;
        isGarlicEquipped = false;
        isFireballEquipped = false;
        isQuennBookEquipped = false;
        isMagnetEquipped = false;
        isMaxHealhEquipped = false;
        isItemSpeedBookEquipped = false;
        isWingsEquipped = false;
    }
}
