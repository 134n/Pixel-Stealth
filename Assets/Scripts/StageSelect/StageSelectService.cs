using VContainer;

public class StageSelectService
{
    private ScreenChange screenChange;

    [Inject]
    public void Inject(ScreenChange screenChange)
    {
        this.screenChange = screenChange;
    }

    public void OnClickButtonScreenChange(ScreenStatus.Screen nextscreen)
    {
        screenChange.ChangeScreen(nextscreen);
    }

    public void OnClickButtonScreenChangeByName(string nextScreen)
    {
        screenChange.ChangeScreenByName(nextScreen);
    }
}
