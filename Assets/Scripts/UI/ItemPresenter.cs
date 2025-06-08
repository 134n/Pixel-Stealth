using VContainer;
using VContainer.Unity;
using UniRx;
using UniRx.Triggers;

public class ItemPresenter : IStartable
{
    private readonly ItemEffectManager coinEffectManager;

    private readonly PlayerView playerView;

    [Inject]
    public ItemPresenter(ItemEffectManager coinEffectManager, PlayerView playerView)
    {
        this.coinEffectManager = coinEffectManager;
        this.playerView = playerView;
    }

    void IStartable.Start()
    {
        playerView.Player.OnTriggerEnter2DAsObservable()
            .Where(other => other.gameObject.name == "ItemKey")
            .Subscribe(other =>
            {
                coinEffectManager.Play();
            })
            .AddTo(playerView);
    }
}