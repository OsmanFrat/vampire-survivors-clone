using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpColorfullBar : MonoBehaviour
{
    public Image uiImage;
    public float duration = 1f;

    private void Start()
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        Color startColor = Color.red;
        Color endColor = Color.blue;
        float elapsedTime = 0f;

        while (true)
        {
            while (elapsedTime < duration)
            {
                uiImage.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }

            Color temp = startColor;
            startColor = endColor;
            endColor = temp;
            elapsedTime = 0f;
        }
    }
}
