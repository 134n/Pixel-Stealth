using UniRx;
using VContainer;
using VContainer.Unity;

public class GoalNaviPresenter : IStartable
{
    private GoalNaviView goalNaviView;

    private GoalNaviService goalNaviService;

    private GoalController goalController;

    [Inject]
    public GoalNaviPresenter(GoalNaviView goalNaviView, GoalNaviService goalNaviService,
                                GoalController goalController)
    {
        this.goalNaviView = goalNaviView;
        this.goalNaviService = goalNaviService;
        this.goalController = goalController;
    }

    void IStartable.Start()
    {
        goalNaviService.NonDisplayGoalNaviObj();

        goalNaviView.GoalSubject
            .Where(_ => goalController.IsGoal)
            .Subscribe(_ =>
            {
                goalNaviService.DisplayGoalObj();
                goalNaviService.NaviObjTweenYOYO();
            })
            .AddTo(goalNaviView);
    }
}
