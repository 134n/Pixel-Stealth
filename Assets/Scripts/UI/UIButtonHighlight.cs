using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class UIButtonHighlight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Vector3 originalScale;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform
        .DOScale(originalScale * 1.1f, 0.1f)
        .SetEase(Ease.OutBack)
        .SetLink(gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rectTransform
        .DOScale(originalScale, 0.1f)
        .SetEase(Ease.InOutSine)
        .SetLink(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform
        .DOScale(originalScale, 0.1f)
        .SetEase(Ease.InOutSine)
        .SetLink(gameObject);
    }
}
