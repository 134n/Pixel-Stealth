using VContainer;
using VContainer.Unity;

public class EnemyAttackOncePresenter : IStartable
{
    private readonly EnemyAttackOnceService enemyAttackOnceService;

    [Inject]
    public EnemyAttackOncePresenter(
        EnemyAttackOnceService enemyAttackOnceService)
    {
        this.enemyAttackOnceService = enemyAttackOnceService;
    }

    void IStartable.Start()
    {
        enemyAttackOnceService.PlayerSearchEnable();
        enemyAttackOnceService.PlayerSearchDisable();
        enemyAttackOnceService.PlayerSearchEXEnable();
        enemyAttackOnceService.PlayerSearchEXDisable();
        enemyAttackOnceService.EnemyAttackOnceForAgent();
        enemyAttackOnceService.EnemyAttackOnce();
    }
}
