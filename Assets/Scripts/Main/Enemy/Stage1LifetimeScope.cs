using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Stage1LifetimeScope : LifetimeScope
{
    [SerializeField] private EnemyCollider enemyCollider;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);
        builder.RegisterComponent(enemyCollider);
    }
}
