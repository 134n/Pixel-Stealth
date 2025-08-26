using UniRx;
using VContainer;
using VContainer.Unity;

public class GameOverPresenter : IStartable
{
    private GameOverView gameOverView;

    private GameOverService gameOverService;

    private ScreenChange screenChange;

    private PlayerView playerView;

    private ResultDataStore resultDataStore;

    private ResultService resultService;

    [Inject]
    public GameOverPresenter(GameOverView gameOverView, GameOverService gameOverService,
        ScreenChange screenChange, PlayerView playerView, ResultDataStore resultDataStore,
        ResultService resultService)
    {
        this.gameOverView = gameOverView;
        this.gameOverService = gameOverService;
        this.screenChange = screenChange;
        this.playerView = playerView;
        this.resultDataStore = resultDataStore;
        this.resultService = resultService;
    }

    void IStartable.Start()
    {
        gameOverService.NonDisplayGameOver();

        gameOverService.LimitSub
            .Subscribe(async _ =>
            {
                resultService.LoadRetryScene();
                resultService.SaveRetryScene();
                playerView.Player.SetActive(false);
                gameOverService.DisplayGameOver();
                gameOverService.SetGameOverResultData();
                await resultDataStore.SubmitScoreAsync();
            })
            .AddTo(gameOverView);

        gameOverView.ResultButton.OnClickAsObservable()
            .Subscribe(_ => screenChange.ChangeScreen(ScreenStatus.Screen.Result))
            .AddTo(gameOverView);
    }
}
