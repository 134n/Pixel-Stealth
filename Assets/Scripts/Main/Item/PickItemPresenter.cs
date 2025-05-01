using UniRx;
using UniRx.Triggers;
using VContainer;
using VContainer.Unity;

public class PickItemPresenter : IStartable
{
    private PlayerView playerView;

    private GetKey getKey;

    private HUDService hUDService;

    [Inject]
    public void Inject(PlayerView playerView, GetKey getKey, HUDService hUDService)
    {
        this.playerView = playerView;
        this.getKey = getKey;
        this.hUDService = hUDService;
    }

    private const string Key = "ItemKey";

    void IStartable.Start()
    {
        playerView.Player.OnTriggerEnter2DAsObservable()
            .Where(other => other.gameObject.name == Key)
            .Subscribe(other =>
            {
                getKey.ItemPick();
                hUDService.CollectItem();
                playerView.DestroyObj(other.gameObject);
            })
            .AddTo(playerView);
    }
}