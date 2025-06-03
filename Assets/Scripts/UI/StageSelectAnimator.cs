using VContainer;
using VContainer.Unity;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectAnimator : IStartable
{
    private StageSelectButton stageSelectButton;

    [Inject]
    public void StageSelectButton(StageSelectButton stageSelectButton)
    {
        this.stageSelectButton = stageSelectButton;
    }

    void IStartable.Start()
    {
        var seq = DOTween.Sequence();
        int index = 0;

        foreach (var Stages in stageSelectButton.Stages)
        {
            var rect = Stages.GetComponent<RectTransform>();
            var image = Stages.GetComponent<Image>();
            var deray = index * 0.1f;


            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 600);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);


            seq.Insert(deray, rect.DOAnchorPosY(400, 0.2f)
            .SetEase(Ease.OutQuad)
            .SetLink(stageSelectButton.gameObject));

            seq.Insert(deray, image.DOFade(1, 0.2f)
            .SetEase(Ease.OutSine)
            .SetLink(stageSelectButton.gameObject));

            index++;
        }

        var buckRect = stageSelectButton.Buck.GetComponent<RectTransform>();
        buckRect.anchoredPosition = new Vector2(-800, buckRect.anchoredPosition.y);

        buckRect.DOAnchorPosX(0, 0.2f)
            .SetEase(Ease.OutQuad)
            .SetLink(stageSelectButton.Buck.gameObject);
    }
}
