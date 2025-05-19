using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer.Unity;

public class GameClearPresenter : IStartable
{
    private GameClear gameClear;

    private GameClearService gameClearService;

    private GoalController goalController;

    private ScreenChange screenChange;

    private HUDService hUDService;

    private ResultDataStore resultDataStore;

    public GameClearPresenter(GameClear gameClear, GameClearService gameClearService, GoalController
        goalController, ScreenChange screenChange, HUDService hUDService, ResultDataStore resultDataStore)
    {
        this.gameClear = gameClear;
        this.gameClearService = gameClearService;
        this.goalController = goalController;
        this.screenChange = screenChange;
        this.hUDService = hUDService;
        this.resultDataStore = resultDataStore;
    }

    void IStartable.Start()
    {
        gameClearService.NonDisplayGameClear();

        goalController.GoalObject.OnTriggerEnter2DAsObservable()
            .Where(other => other.gameObject.name == "Player")
            .Subscribe(async other =>
            {
                gameClearService.DisplayGameClear();
                hUDService.TimerStop();
                gameClearService.SetGameClearResultData();
                other.gameObject.SetActive(false);
                Object.Destroy(other.gameObject);
                await resultDataStore.SubmitScoreAsync();
            })
            .AddTo(goalController);

        gameClear.resultButton.OnClickAsObservable()
            .Subscribe(_ => screenChange.ChangeScreen(ScreenStatus.Screen.Result))
            .AddTo(gameClear);
    }
}
