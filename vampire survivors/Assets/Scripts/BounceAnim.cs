using UnityEngine;
using DG.Tweening;

public class BounceAnim : MonoBehaviour
{
    void Start()
    {
        Bounce();
    }

    private void Bounce()
    {
        Sequence bounceSequence = DOTween.Sequence();

        bounceSequence.Append(transform.DOScaleY(4, 0.15f));
        bounceSequence.Append(transform.DOScaleX(2, 0.15f));
        bounceSequence.Append(transform.DOScaleY(2, 0.15f));
        bounceSequence.Append(transform.DOScaleX(4, 0.15f));
        bounceSequence.Append(transform.DOScale(3, 0.15f));
    }
}
