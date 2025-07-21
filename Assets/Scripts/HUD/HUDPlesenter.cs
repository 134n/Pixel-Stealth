using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

public class HUDPlesenter : ITickable, IAsyncStartable
{
    public HUDService hUDService;

    public HUDManager hUDManager;

    private GameStartCountDown gameStart;

    [Inject]
    public void Inject(HUDService hUDService, HUDManager hUDManager, GameStartCountDown gameStart)
    {
        this.hUDService = hUDService;
        this.hUDManager = hUDManager;
        this.gameStart = gameStart;
    }

    public async UniTask StartAsync(CancellationToken cancellation = default)
    {
        hUDService.StageName();
        hUDService.ObjectiveText();
        hUDService.ItemPickUI();
        hUDService.TimerStop();
        await gameStart.StartCountDownAsync(cancellation);
        hUDService.StartTimer();
    }

    void ITickable.Tick()
    {
        hUDService.UpdateTimer();
    }
}
