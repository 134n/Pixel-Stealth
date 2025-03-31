using UniRx;
using UniRx.Triggers;
using VContainer;
using VContainer.Unity;

public class PickItemPresenter : IStartable
{
    private PlayerView playerView;

    private GetKey getKey;

    [Inject]
    public void Inject(PlayerView playerView, GetKey getKey)
    {
        this.playerView = playerView;
        this.getKey = getKey;
    }

    private const string Key = "ItemKey";

    void IStartable.Start()
    {
        playerView.Player.OnTriggerEnter2DAsObservable()
            .Where(other => other.gameObject.name == Key)
            .Subscribe(other =>
            {
                getKey.ItemPick();
                playerView.DestroyObj(other.gameObject);
            })
            .AddTo(playerView);
    }
}