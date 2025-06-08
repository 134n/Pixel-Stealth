using UnityEngine;
using VContainer;
using VContainer.Unity;
using DG.Tweening;

public class ResultSceneButtonAnimator : IStartable
{

    private readonly ResultView resultView;

    private readonly int setPosX = -800;

    [Inject]
    public ResultSceneButtonAnimator(ResultView resultView)
    {
        this.resultView = resultView;
    }

    void IStartable.Start()
    {
        var sq = DOTween.Sequence();

        var rankingRect = resultView.Ranking.GetComponent<RectTransform>();
        var retryRect = resultView.Retry.GetComponent<RectTransform>();
        var toTitleRect = resultView.ToTitle.GetComponent<RectTransform>();

        rankingRect.anchoredPosition = new Vector2(setPosX, rankingRect.anchoredPosition.y);
        retryRect.anchoredPosition = new Vector2(setPosX, retryRect.anchoredPosition.y);
        toTitleRect.anchoredPosition = new Vector2(setPosX, toTitleRect.anchoredPosition.y);

        sq.Append(rankingRect.DOAnchorPos(new Vector2(0, rankingRect.anchoredPosition.y), 1f))
            .SetEase(Ease.OutQuad)
            .SetLink(rankingRect.gameObject);

        sq.Append(retryRect.DOAnchorPos(new Vector2(0, retryRect.anchoredPosition.y), 1f))
            .SetEase(Ease.OutQuad)
            .SetLink(retryRect.gameObject);

        sq.Append(toTitleRect.DOAnchorPos(new Vector2(0, toTitleRect.anchoredPosition.y), 1f))
            .SetEase(Ease.OutQuad)
            .SetLink(toTitleRect.gameObject);
    }
}
