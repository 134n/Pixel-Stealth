using Cysharp.Threading.Tasks;
using UniRx;
using VContainer;
using VContainer.Unity;

public class GoalPresenter : IStartable
{
    readonly GoalService service;

    readonly GoalController goalController;

    private readonly PlayerStatus playerStatus;

    private ResultService resultService;

    private GoalNaviView goalNaviView;

    [Inject]
    public GoalPresenter(GoalService service, GoalController goalController, PlayerStatus playerStatus
                            , ResultService resultService, GoalNaviView goalNaviView)
    {
        this.service = service;
        this.goalController = goalController;
        this.playerStatus = playerStatus;
        this.resultService = resultService;
        this.goalNaviView = goalNaviView;
    }

    void IStartable.Start()
    {
        service.NonDisplayGoalObj();
        resultService.SaveRetryScene();

        playerStatus.Key
            .Where(key => key >= goalController.RequiredItemCount)
            .Subscribe(_ =>
            {
                service.DisplayGoalObj();
                goalNaviView.TriggerGoalNavi();
            })
            .AddTo(goalController.GoalObject);
    }
}