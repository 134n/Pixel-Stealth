using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using VContainer.Unity;

public class GoalPresenter : IStartable
{
    readonly GoalService service;

    readonly GoalController goalController;

    private readonly PlayerStatus playerStatus;

    private readonly PlayerPickItemController playerPickItemController;

    public GoalPresenter(GoalService service, GoalController goalController, PlayerStatus playerStatus, PlayerPickItemController playerPickItemController)
    {
        this.service = service;
        this.goalController = goalController;
        this.playerStatus = playerStatus;
        this.playerPickItemController = playerPickItemController;
    }

    void IStartable.Start()
    {
        service.NonDisplayGoalObj();

        playerPickItemController.UpdateAsObservable()
            .Where(_ => playerStatus.Key >= 3)
            .Subscribe(_ => service.DisplayGoalObj())
            .AddTo(goalController);
    }
}