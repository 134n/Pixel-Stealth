using VContainer;
using VContainer.Unity;

public class HUDPlesenter : ITickable , IStartable
{
    public HUDService hUDService;

    public HUDManager hUDManager;

    [Inject] public void Inject(HUDService hUDService,HUDManager hUDManager)
    {
        this.hUDService = hUDService;
        this.hUDManager = hUDManager;
    }

    void IStartable.Start()
    {
        hUDService.StageName();
        hUDService.ObjectiveText();
        hUDService.ItemPickUI();
        hUDService.StartTimer();
    }

    void ITickable.Tick()
    {
        hUDService.UpdateTimer();
    }
}
