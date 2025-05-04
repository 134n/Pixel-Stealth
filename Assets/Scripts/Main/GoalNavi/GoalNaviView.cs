using System;
using UniRx;
using UnityEngine;

public interface IGoalNavi
{
    GameObject GoalNaviObj { get; }
}

public class GoalNaviView : MonoBehaviour, IGoalNavi
{
    [SerializeField] private GameObject goalNaviObj;

    public GameObject GoalNaviObj
    {
        get => goalNaviObj;
        //set => goalNaviObj = value;
    }

    //public GameObject GoalNaviObj => goalNaviObj;　こっちの方がわかりやすい

    private readonly Subject<Unit> goalSubject = new Subject<Unit>();
    public IObservable<Unit> GoalSubject => goalSubject;

    public void TriggerGoalNavi()
    {
        goalSubject.OnNext(Unit.Default);
    }
}
