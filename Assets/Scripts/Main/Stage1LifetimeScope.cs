using Unity.Services.Analytics;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Stage1LifetimeScope : LifetimeScope
{
    [SerializeField] private EnemyCollider enemyCollider;

    [SerializeField] private EnemyTrack enemyTrack;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);
        builder.Register<PlayerStatus>(Lifetime.Singleton);
        builder.Register<FollowPlayer>(Lifetime.Singleton);
        builder.Register<WanderingEnemy>(Lifetime.Singleton);
        builder.Register<WaitTime>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<PlayerView>();
        builder.RegisterEntryPoint<PickItemPresenter>();
        builder.Register<GetKey>(Lifetime.Singleton);

        builder.RegisterComponent(enemyCollider);
        builder.RegisterComponent(enemyTrack);

        builder.RegisterComponentInHierarchy<GoalController>();
        builder.RegisterComponentInHierarchy<GameClear>();
        builder.RegisterEntryPoint<GoalPresenter>();
        builder.RegisterEntryPoint<GameClearPresenter>();
        builder.Register<GoalService>(Lifetime.Scoped);
        builder.Register<GameClearService>(Lifetime.Singleton);
    }
}
