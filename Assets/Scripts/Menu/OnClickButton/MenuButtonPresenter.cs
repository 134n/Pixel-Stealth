using UniRx;
using VContainer;
using VContainer.Unity;

public class MenuButtonPresenter : IStartable
{
    private readonly IMenuButtonView view;
    private readonly MenuButtonService service;
    private readonly CompositeDisposable disposable = new();

    public MenuButtonPresenter(IMenuButtonView view, MenuButtonService service)
    {
        this.view = view;
        this.service = service;
    }

    void IStartable.Start()
    {
        view.OpenMessagePanel
            .Subscribe(_ => view.ShowMessagePanel())
            .AddTo(disposable);

        view.CloseMessagePanel
            .Subscribe(_ => view.HideMessagePanel())
            .AddTo(disposable);

        view.OpenVolumePanel
            .Subscribe(_ => view.ShowVolumePanel())
            .AddTo(disposable);

        view.CloseVolumePanel
            .Subscribe(_ => view.HideVolumePanel())
            .AddTo(disposable);
    }

    public void Dispose() => disposable.Dispose();
}