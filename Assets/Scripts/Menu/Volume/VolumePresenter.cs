using System;
using UniRx;
using VContainer.Unity;

public class VolumePresenter : IStartable, IDisposable
{
    private readonly IVolumeView view;
    private readonly AudioSettingService service;
    private readonly CompositeDisposable disposables = new();

    public VolumePresenter(IVolumeView view, AudioSettingService service)
    {
        this.view = view;
        this.service = service;
    }
    void IStartable.Start()
    {
        //デフォルト
        float se = service.GetSeVolume();
        float bgm = service.GetBgmVolume();
        // UI に反映
        view.SetSeSlider(se);
        view.SetBgmSlider(bgm);
        // 実際の音量にも反映
        service.ApplyAll();

        view.OnChangeSeVolume
            .Subscribe(service.SetSeVolume)
            .AddTo(disposables);

        view.OnChangeBgmVolume
            .Subscribe(service.SetBgmVolume)
            .AddTo(disposables);
    }

    public void Dispose() => disposables.Dispose();
}
