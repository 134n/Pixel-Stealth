using Unity.Services.Analytics;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Stage1LifetimeScope : LifetimeScope
{
    [SerializeField] private EnemyCollider enemyCollider;

    [SerializeField] private PlayerPickItemController playerPickItemController;

    [SerializeField] private EnemyTrack enemyTrack;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);
        builder.Register<ItemKey>(Lifetime.Singleton);
        builder.Register<ItemMatatabi>(Lifetime.Singleton);
        builder.Register<PlayerStatus>(Lifetime.Singleton);
        builder.Register<FollowPlayer>(Lifetime.Singleton);
        builder.Register<WanderingEnemy>(Lifetime.Singleton);
        builder.Register<WaitTime>(Lifetime.Singleton);

        builder.RegisterComponent(playerPickItemController);
        builder.RegisterComponent(enemyCollider);
        builder.RegisterComponent(enemyTrack);
    }
}
