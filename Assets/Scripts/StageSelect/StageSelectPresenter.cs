using System.Linq;
using KanKikuchi.AudioManager;
using UniRx;
using VContainer;
using VContainer.Unity;

public class StageSelectPresenter : IStartable
{
    private StageSelectButton stageSelectButton;

    private StageSelectService stageSelectService;

    [Inject]
    public StageSelectPresenter(StageSelectButton stageSelectButton, StageSelectService stageSelectService)
    {
        this.stageSelectButton = stageSelectButton;
        this.stageSelectService = stageSelectService;
    }

    void IStartable.Start()
    {
        BGMManager.Instance.FadeOut();
        
        Observable.Merge(
            stageSelectButton.Stages.Select(button => button.OnClickAsObservable().Select(_ => button.name)))
            .Subscribe(name => stageSelectService.OnClickButtonScreenChangeByName(name))
            .AddTo(stageSelectButton);

        stageSelectButton.Buck.OnClickAsObservable()
            .Subscribe(_ => stageSelectService.OnClickButtonScreenChange(ScreenStatus.Screen.Title))
            .AddTo(stageSelectButton);
    }
}
