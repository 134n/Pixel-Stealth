using DG.Tweening;
using KanKikuchi.AudioManager;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TitleButtonAnimator : IStartable
{
    private TitleView titleView;

    [Inject]
    public TitleButtonAnimator(TitleView titleView)
    {
        this.titleView = titleView;
    }

    void IStartable.Start()
    {
        // 左からスライドイン
        var stageRect = titleView.StageSelect.GetComponent<RectTransform>();
        var menuRect = titleView.Menu.GetComponent<RectTransform>();

        stageRect.anchoredPosition = new Vector2(-800f, stageRect.anchoredPosition.y);
        menuRect.anchoredPosition = new Vector2(-800f, menuRect.anchoredPosition.y);

        stageRect.DOAnchorPos(new Vector2(200f, stageRect.anchoredPosition.y), 1f)
            .SetEase(Ease.OutQuad)
            //.OnComplete(() => SEManager.Instance.Play(SEPath.TAP1))
            .SetLink(titleView.StageSelect.gameObject);

        menuRect.DOAnchorPos(new Vector2(200f, menuRect.anchoredPosition.y), 1f)
            .SetEase(Ease.OutQuad)
            .SetDelay(0.2f)
            //.OnComplete(() => SEManager.Instance.Play(SEPath.TAP1))
            .SetLink(titleView.Menu.gameObject);
    }
}
