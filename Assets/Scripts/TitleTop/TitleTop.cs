using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class TitleTop : MonoBehaviour
{
    [SerializeField] Button stageSelect;
    [SerializeField] Button menu;

    private ScreenChange screenChange;

    [Inject]
    public void Inject(ScreenChange screenChange)
    {
        this.screenChange = screenChange;
    }

    public void Start()
    {
        stageSelect.OnClickAsObservable()
                .Subscribe(_ => screenChange.ScreenChanged(ScreenStatus.Screen.StageSelect))
                .AddTo(this);
        
        menu.OnClickAsObservable()
                .Subscribe(_ => screenChange.ScreenChanged(ScreenStatus.Screen.Menu))
                .AddTo(this);
    }
}