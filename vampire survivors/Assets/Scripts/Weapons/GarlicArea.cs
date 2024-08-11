using UnityEngine;

public class GarlicArea : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRen;
    [SerializeField] private Sprite oneCircleSprite, twoCircleSprite, threeCircleSprite;
    [SerializeField] private CircleCollider2D circleCol;

    //public int circleLevel = 1;
    public WeaponAndItemLevel weaponAndItemLevel;

    private void Update()
    {
        ChangeSpriteAndCollider();
        
        //For testing
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    circleLevel++;
        //}
    }

    private void ChangeSpriteAndCollider()
    {
        switch (weaponAndItemLevel.GarlicLevel)
        {
            case 1:
                spriteRen.sprite = oneCircleSprite;
                circleCol.radius = 0.13f;
                break;
            case 2:
                spriteRen.sprite = twoCircleSprite;
                circleCol.radius = 0.22f;
                break;
            case 3:
                spriteRen.sprite = threeCircleSprite;
                circleCol.radius = 0.32f;
                break;
            default:
                spriteRen.sprite = oneCircleSprite;
                circleCol.radius = 0.13f;
                break;
        }
    }
}
