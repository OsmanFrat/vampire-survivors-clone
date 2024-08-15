using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenBook : MonoBehaviour
{
    public WeaponsAndItems weaponsAndItems;

    public BoxCollider2D secondBookCollider;
    public BoxCollider2D thirdBookCollider;
    public BoxCollider2D fourthBookCollider;

    public SpriteRenderer secondBookSprite;
    public SpriteRenderer thirdBookSprite;
    public SpriteRenderer fourthBookSprite;
    private void Start()
    {
        GameObject secondBookObject = GameObject.Find("QueenBook_2");
        secondBookCollider = secondBookObject.GetComponent<BoxCollider2D>();
        secondBookSprite = secondBookObject.GetComponent<SpriteRenderer>();

        GameObject thirdBookObject = GameObject.Find("QueenBook_3");
        thirdBookCollider = thirdBookObject.GetComponent<BoxCollider2D>();
        thirdBookSprite = thirdBookObject.GetComponent<SpriteRenderer>();

        GameObject fourthBookObject = GameObject.Find("QueenBook_4");
        fourthBookCollider = fourthBookObject.GetComponent<BoxCollider2D>();
        fourthBookSprite = fourthBookObject.GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        UpdateQueenBooks();
    }

    private void UpdateQueenBooks()
    {
        switch (weaponsAndItems.QuennBookLevel)
        {
            case 1:
                //Debug.Log("QueenBook obtained!");
                break;
            case 2:
                secondBookSprite.enabled = true;
                secondBookCollider.enabled = true;
                break;
            case 3:
                secondBookSprite.enabled = true;
                secondBookCollider.enabled = true;

                thirdBookSprite.enabled = true;
                thirdBookCollider.enabled = true;

                fourthBookCollider.enabled = true;
                fourthBookSprite.enabled = true;
                break;
            default:
                secondBookSprite.enabled = false;
                secondBookCollider.enabled = false;

                thirdBookSprite.enabled = false;
                thirdBookCollider.enabled = false;

                fourthBookCollider.enabled = false;
                fourthBookSprite.enabled = false;
                break;
        }
    }
}
