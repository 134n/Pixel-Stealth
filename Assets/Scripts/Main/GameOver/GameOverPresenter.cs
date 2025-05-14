using UniRx;
using VContainer;
using VContainer.Unity;

public class GameOverPresenter : IStartable
{
    private GameOverView gameOverView;

    private GameOverService gameOverService;

    private ScreenChange screenChange;

    private PlayerView playerView;

    [Inject]
    public GameOverPresenter(GameOverView gameOverView, GameOverService gameOverService,
        ScreenChange screenChange, PlayerView playerView)
    {
        this.gameOverView = gameOverView;
        this.gameOverService = gameOverService;
        this.screenChange = screenChange;
        this.playerView = playerView;
    }

    void IStartable.Start()
    {
        gameOverService.NonDisplayGameOver();

        gameOverService.LimitSub
            .Subscribe(_ =>
            {
                playerView.Player.SetActive(false);
                gameOverService.DisplayGameOver();
                gameOverService.SetGameOverResultData();
            })
            .AddTo(gameOverView);

        gameOverView.ResultButton.OnClickAsObservable()
            .Subscribe(_ => screenChange.ChangeScreen(ScreenStatus.Screen.Result))
            .AddTo(gameOverView);
    }
}
