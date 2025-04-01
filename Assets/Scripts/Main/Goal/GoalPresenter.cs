using Cysharp.Threading.Tasks;
using UniRx;
using VContainer.Unity;

public class GoalPresenter : IStartable
{
    readonly GoalService service;

    readonly GoalController goalController;

    private readonly PlayerStatus playerStatus;

    public GoalPresenter(GoalService service, GoalController goalController, PlayerStatus playerStatus)
    {
        this.service = service;
        this.goalController = goalController;
        this.playerStatus = playerStatus;
    }

    void IStartable.Start()
    {
        service.NonDisplayGoalObj();

        playerStatus.Key
            .Where(key => key >= goalController.RequiredItemCount)
            .Subscribe(_ => service.DisplayGoalObj())
            .AddTo(goalController.GoalObject);
    }
}