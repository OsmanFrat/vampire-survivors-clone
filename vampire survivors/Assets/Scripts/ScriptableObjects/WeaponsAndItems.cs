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
    public int QueenBookLevel = 1;
    public bool isQueenBookEquipped = false;

    [Space(10)]
    [Header("Pentagram")]
    public int PentagramLevel = 1;
    public bool isPentagramEquipped = false;

    [Space(20)]
    [Header("---------- Items ------------")]

    [Space(10)]
    [Header("Magnet")]
    public int MagnetLevel = 1;
    public bool isMagnetEquipped = false;

    [Space(10)]
    [Header("Max Health")]
    public int MaxHealthLevel = 1;
    public bool isMaxHealhEquipped = false;

    [Space(10)]
    [Header("Fast Hamburger")]
    public int FastHamburgerLevel = 1;
    public bool isFastHamburgerEquipped = false;

    [Space(10)]
    [Header("Wings")]
    public int WingsLevel = 1;
    public bool isWingsEquipped = false;

    public void ResetValues()
    {
        GarlicLevel = 1;
        FireballLevel = 1;
        BladeLevel = 1;
        QueenBookLevel = 1;
        PentagramLevel = 1;

        MagnetLevel = 1;
        MaxHealthLevel = 1;
        FastHamburgerLevel = 1;
        WingsLevel = 1;

        isBladeEquipped = true;
        isGarlicEquipped = false;
        isFireballEquipped = false;
        isQueenBookEquipped = false;
        isPentagramEquipped = false;

        isMagnetEquipped = false;
        isMaxHealhEquipped = false;
        isFastHamburgerEquipped = false;
        isWingsEquipped = false;
    }
}
