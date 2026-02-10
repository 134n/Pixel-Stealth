public class GameOverPlayerService
{
    public bool IsGameOver { get; private set; }

    public bool TryGameOver()
    {
        if (IsGameOver) return false;
        IsGameOver = true;
        return true;
    }
}
