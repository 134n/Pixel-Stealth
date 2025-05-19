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

    [Inject]
    public GameOverPresenter(GameOverView gameOverView, GameOverService gameOverService,
        ScreenChange screenChange, PlayerView playerView, ResultDataStore resultDataStore)
    {
        this.gameOverView = gameOverView;
        this.gameOverService = gameOverService;
        this.screenChange = screenChange;
        this.playerView = playerView;
        this.resultDataStore = resultDataStore;
    }

    void IStartable.Start()
    {
        gameOverService.NonDisplayGameOver();

        gameOverService.LimitSub
            .Subscribe(async _ =>
            {
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
