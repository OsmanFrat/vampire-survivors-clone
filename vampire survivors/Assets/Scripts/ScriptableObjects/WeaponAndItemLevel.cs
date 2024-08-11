using UnityEngine;

[CreateAssetMenu(fileName = "WeaponAndItemLevel", menuName = "Scriptable_Objests/WeaponAndItemLevel")]
public class WeaponAndItemLevel : ScriptableObject
{   
    [Header("---------- Weapon Levels ----------")]

    [Space(10)]
    [Header("Garlic")]
    public int GarlicLevel = 1;
    
    [Space(10)]
    [Header("Fireball")]
    public int FireballLevel = 1;
    
    [Space(10)]
    [Header("Blade")]
    public int BladeLevel = 1;
    
    [Space(10)]
    [Header("Queen Book")]
    public int QuennBookLevel = 1;

    [Space(20)]
    [Header("---------- Item Levels ----------")]

    [Space(10)]
    [Header("Magnet")]
    public int MagnetLevel = 1;

    [Space(10)]
    [Header("Max Healh")]
    public int MaxHealthLevel = 1;

    [Space(10)]
    [Header("Item Speed Book")]
    public int ItemSpeedBookLevel = 1;

    [Space(10)]
    [Header("Wing")]
    public int WingLevel = 1;


    public void ResetValues()
    {
        GarlicLevel = 1;
        FireballLevel = 1;
        BladeLevel = 1;
        QuennBookLevel = 1;
        MagnetLevel = 1;
        MaxHealthLevel = 1;
        ItemSpeedBookLevel = 1;
        WingLevel = 1;
    }



}
