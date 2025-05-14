public class GameClearService
{
    private GameClear gameClear;

    private HUDManager hUDManager;

    public GameClearService(GameClear gameClear,HUDManager hUDManager) { 
        this.gameClear = gameClear; 
        this.hUDManager = hUDManager;
        }
    
    /// <summary>
    /// ゲームクリア画面の非表示
    /// </summary>
    public void NonDisplayGameClear()
    {
        gameClear.gameClearObj.SetActive(false);
    }

    /// <summary>
    /// ゲームクリア画面の表示
    /// </summary>
    public void DisplayGameClear()
    {
        gameClear.gameClearObj.SetActive(true);
    }

    public void SetGameClearResultData()
    {
        ResultDataStore.LimitTimeData = hUDManager.limitTime;
    }
}
