using Unity.Services.Analytics;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Stage1LifetimeScope : LifetimeScope
{
    [SerializeField] private EnemyCollider enemyCollider;

    [SerializeField] private PlayerPickItemController playerPickItemController;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);
        builder.RegisterComponent(enemyCollider);

        builder.Register<ItemKey>(Lifetime.Singleton);
        builder.Register<ItemMatatabi>(Lifetime.Singleton);
        builder.Register<PlayerStatus>(Lifetime.Singleton);
        builder.RegisterComponent(playerPickItemController);
    }
}
