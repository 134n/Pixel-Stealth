public class GoalService
{
    private GoalController goalController;

    public GoalService(GoalController goalController,GameClear gameClear)
    {
        this.goalController = goalController;
    }

    /// <summary>
    /// ゴールの非表示
    /// </summary>
    public void NonDisplayGoalObj()
    {
        goalController.goalObject.SetActive(false);
    }

    /// <summary>
    /// ゴールの表示
    /// </summary>
    public void DisplayGoalObj()
    {
        goalController.goalObject.SetActive(true);
    }
}