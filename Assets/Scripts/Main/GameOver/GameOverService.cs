using UniRx;
using VContainer;

public class GameOverService
{
    private GameOverView gameOverView;

    [Inject]
    public GameOverService(GameOverView gameOverView)
    {
        this.gameOverView = gameOverView;
    }

    public void DisplayGameOver()
    {
        gameOverView.GameOverObj.SetActive(true);
    }

    public void NonDisplayGameOver()
    {
        gameOverView.GameOverObj.SetActive(false);
    }

    private Subject<Unit> limitSub = new Subject<Unit>();
    public Subject<Unit> LimitSub => limitSub;

    public void LimitTimeSubject()
    {
        LimitSub.OnNext(Unit.Default);
    }

    public void SetGameOverResultData()
    {
        ResultDataStore.LimitTimeData = 0;
    }
}
