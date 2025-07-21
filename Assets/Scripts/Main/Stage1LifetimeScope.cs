using VContainer;
using VContainer.Unity;

public class Stage1LifetimeScope : LifetimeScope
{
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

        builder.RegisterComponentInHierarchy<EnemyCollider>();
        builder.RegisterComponentInHierarchy<EnemyTrack>();

        builder.RegisterComponentInHierarchy<GoalController>();
        builder.RegisterComponentInHierarchy<GameClear>();
        builder.RegisterEntryPoint<GoalPresenter>();
        builder.RegisterEntryPoint<GameClearPresenter>();
        builder.Register<GoalService>(Lifetime.Scoped);
        builder.Register<GameClearService>(Lifetime.Singleton);

        builder.Register<ResultService>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<HUDManager>();
        builder.RegisterEntryPoint<HUDPlesenter>();
        builder.Register<HUDService>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<GoalNaviView>();
        builder.RegisterEntryPoint<GoalNaviPresenter>();
        builder.Register<GoalNaviService>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<GameOverView>();
        builder.RegisterEntryPoint<GameOverPresenter>();
        builder.Register<GameOverService>(Lifetime.Singleton);

        builder.Register<ResultDataStore>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<ItemEffectManager>();
        builder.RegisterEntryPoint<ItemPresenter>();

        builder.RegisterComponentInHierarchy<Move>();
        builder.RegisterEntryPoint<SlimeParameter>();

        builder.RegisterComponentInHierarchy<GameStartCountDown>();
    }
}
