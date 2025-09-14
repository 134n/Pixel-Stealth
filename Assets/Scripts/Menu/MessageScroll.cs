using UnityEngine;
using DG.Tweening;

public class MessageScroll : MonoBehaviour
{
    [SerializeField] private RectTransform textRect;

    [SerializeField] private float moveY;

    [SerializeField] private float duration;

    private void Start()
    {
        Vector3 startPos = textRect.anchoredPosition;

        textRect.DOAnchorPosY(startPos.y + moveY, duration)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
    }
}
