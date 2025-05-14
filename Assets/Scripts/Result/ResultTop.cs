using UniRx;
using VContainer;
using VContainer.Unity;

public class ResultTop : IStartable
{
    private readonly ResultView resultView;

    private readonly ScreenChange screenChange;

    private readonly ResultService resultService;

    [Inject]
    public ResultTop(ResultView resultView, ScreenChange screenChange,
        ResultService resultService)
    {
        this.resultView = resultView;
        this.screenChange = screenChange;
        this.resultService = resultService;
    }

    void IStartable.Start()
    {
        resultView.ResultTimeText.text = "Time: " + ResultDataStore.LimitTimeData.ToString("F2");

        ResultDataStore.RankData = resultService.RankCheck();
        
        resultView.ResultRankText.text = "Rank: " + ResultDataStore.RankData;

        resultView.ToTitle.OnClickAsObservable()
            .Subscribe(_ => screenChange.ChangeScreen(ScreenStatus.Screen.Title));
            
        resultView.Retry.OnClickAsObservable()
            .Subscribe(_ => resultService.LoadRetryScene());
    }
}