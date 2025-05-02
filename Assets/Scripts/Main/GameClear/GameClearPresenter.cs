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

    private ResultService resultService;

    private HUDService hUDService;

    public GameClearPresenter(GameClear gameClear,GameClearService gameClearService,GoalController 
        goalController,ScreenChange screenChange,ResultService resultService,HUDService hUDService) 
    { 
        this.gameClear  = gameClear;
        this.gameClearService = gameClearService;
        this.goalController = goalController;
        this.screenChange = screenChange;
        this.resultService = resultService;
        this.hUDService = hUDService;
    }

    void IStartable.Start()
    {
        gameClearService.NonDisplayGameClear();

        goalController.GoalObject.OnTriggerEnter2DAsObservable()
            .Where(other => other.gameObject.name == "Player")
            .Subscribe(other => {
                gameClearService.DisplayGameClear();
                Object.Destroy(other.gameObject);
                hUDService.limitTime = false;
                })
            .AddTo(goalController);
        
        gameClear.resultButton.OnClickAsObservable()
            .Subscribe(_ => screenChange.ChangeScreen(ScreenStatus.Screen.Result))
            .AddTo(gameClear);
    }
}
