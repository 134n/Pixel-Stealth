using DG.Tweening;
using UnityEngine;
using VContainer;

public class GoalNaviService
{
    private GoalNaviView goalNaviView;

    [Inject]
    public GoalNaviService(GoalNaviView goalNaviView)
    {
        this.goalNaviView = goalNaviView;
    }

    public void NonDisplayGoalNaviObj()
    {
        goalNaviView.GoalNaviObj.SetActive(false);
    }

    public void DisplayGoalObj()
    {
        goalNaviView.GoalNaviObj.SetActive(true);
    }

    public void NaviObjTweenYOYO()
    {
        goalNaviView.gameObject.transform
            .DOMove(new Vector3(0.02f, 4.4f, 0), 1f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetLink(goalNaviView.gameObject);
    }
}
