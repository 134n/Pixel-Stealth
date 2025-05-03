using UnityEngine;

public class GoalController : MonoBehaviour
{
    private bool isGoal;

    public bool IsGoal
    {
        get => isGoal;
        set => isGoal = value;
    }

    //ゴール
    [SerializeField] private GameObject goalObject;

    public GameObject GoalObject => goalObject;

    //ゲームクリアに必要なアイテム個数
    [SerializeField] private int requiredItemCount;

    public int RequiredItemCount => requiredItemCount;

}