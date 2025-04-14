using UniRx;
using VContainer;
using VContainer.Unity;

public class ResultTop : IStartable
{
    private ScreenChange screenChange;

    private ResultView resultView;

    private ResultService resultService;

    [Inject]
    public void Inject(ScreenChange screenChange,ResultView resultView,ResultService resultService)
    {
        this.screenChange = screenChange;
        this.resultView = resultView;
        this.resultService = resultService;
    }

    void IStartable.Start()
    {
        resultView.ToTitle.OnClickAsObservable()
            .Subscribe(_ => screenChange.ChangeScreen(ScreenStatus.Screen.Title));

        resultView.Retry.OnClickAsObservable()
            .Subscribe(_ => resultService.LoadRetryScene());
    }
}
