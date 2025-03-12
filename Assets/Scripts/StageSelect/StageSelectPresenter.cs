using UniRx;
using VContainer.Unity;

public class StageSelectPresenter : IStartable
{
    private StageSelectButton stageSelectButton;

    private StageSelectService stageSelectService;

    public StageSelectPresenter(StageSelectButton stageSelectButton,StageSelectService stageSelectService)
    {
        this.stageSelectButton = stageSelectButton;
        this.stageSelectService = stageSelectService;
    }

    void IStartable.Start()
    {
        stageSelectButton.stage1.OnClickAsObservable()
            .Subscribe(_ => stageSelectService.OnClickButtonScreenChange(ScreenStatus.Screen.Main))
            .AddTo(stageSelectButton.stage1);
    }
}
