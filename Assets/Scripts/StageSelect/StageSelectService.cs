using UnityEngine;
using UnityEngine.UI;
using UniRx;
using VContainer;

public class StageSelectService 
{
    private ScreenChange screenChange;

    [Inject]
    public void Inject(ScreenChange screenChange)
    {
        this.screenChange = screenChange;
    }

    public void OnClickButtonScreenChange(ScreenStatus.Screen nextScreen)
    {
        screenChange.ScreenChanged(nextScreen);
    }
}
