using KanKikuchi.AudioManager;
using UniRx;
using VContainer;
using VContainer.Unity;
using YuRinChiLibrary.PlayFab;

public class TitleTop : IStartable
{
    private ScreenChange screenChange;

    private TitleView titleView;

    [Inject]
    public void Inject(ScreenChange screenChange, TitleView titleView)
    {
        this.screenChange = screenChange;
        this.titleView = titleView;
    }

    void IStartable.Start()
    {
        PlayFabManager.Instance?.ResetData();

        BGMManager.Instance.Play(BGMPath.NESRPGA042_FIELD_LOOP135);
        BGMManager.Instance.FadeIn(BGMPath.NESRPGA042_FIELD_LOOP135, 3);

        titleView.StageSelect.OnClickAsObservable()
                .Subscribe(_ => { screenChange.ChangeScreen(ScreenStatus.Screen.StageSelect); })
                .AddTo(titleView.StageSelect);

        titleView.Menu.OnClickAsObservable()
                .Subscribe(_ => { screenChange.ChangeScreen(ScreenStatus.Screen.Menu); })
                .AddTo(titleView.StageSelect);
    }
}