using System.Linq;
using UniRx;
using VContainer.Unity;

public class StageSelectPresenter : IStartable
{
    private StageSelectButton stageSelectButton;

    private StageSelectService stageSelectService;

    public StageSelectPresenter(StageSelectButton stageSelectButton, StageSelectService stageSelectService)
    {
        this.stageSelectButton = stageSelectButton;
        this.stageSelectService = stageSelectService;
    }

    void IStartable.Start()
    {
        Observable.Merge(
            stageSelectButton.stage.Select(button => button.OnClickAsObservable().Select(_ => button.name)))
            .Subscribe(name => stageSelectService.OnClickButtonScreenChangeByName(name))
            .AddTo(stageSelectButton);

        stageSelectButton.buck.OnClickAsObservable()
            .Subscribe(_=>stageSelectService.OnClickButtonScreenChange(ScreenStatus.Screen.Title))
            .AddTo(stageSelectButton);
    }
}
