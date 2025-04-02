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

    public GameClearPresenter(GameClear gameClear,GameClearService gameClearService,GoalController 
        goalController,ScreenChange screenChange) 
    { 
        this.gameClear  = gameClear;
        this.gameClearService = gameClearService;
        this.goalController = goalController;
        this.screenChange = screenChange;
    }

    void IStartable.Start()
    {
        gameClearService.NonDisplayGameClear();

        goalController.GoalObject.OnTriggerEnter2DAsObservable()
            .Where(other => other.gameObject.name == "Player")
            .Subscribe(other => {
                gameClearService.DisplayGameClear();
                Object.Destroy(other.gameObject);
                })
            .AddTo(goalController);
        
        gameClear.resultButton.OnClickAsObservable()
            .Subscribe(_ => screenChange.ChangeScreen(ScreenStatus.Screen.Result))
            .AddTo(gameClear);
    }
}
