using UniRx;
using UnityEngine.SceneManagement;


//画面の状態に関するクラス
public class ScreenStatus
{
    public enum Screen
    {
        Title,
        StageSelect,
        Menu,
        Result,
        Main,
    }
}

public sealed class ScreenChange
{
    readonly ReactiveProperty<ScreenStatus.Screen> NowScreen = new();
    public void ScreenChanged(ScreenStatus.Screen nextScreen)
    {
        NowScreen.Value = nextScreen;
        SceneManager.LoadScene(NowScreen.ToString());
    }
}