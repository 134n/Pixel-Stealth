public class GameClearService
{
    private GameClear gameClear;

    public GameClearService(GameClear gameClear) { this.gameClear = gameClear; }
    
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
}
