using VContainer;
using VContainer.Unity;

public class ResultLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);
        builder.Register<ResultService>(Lifetime.Singleton);
        builder.RegisterEntryPoint<ResultTop>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<ResultView>();
        builder.RegisterEntryPoint<ResultSceneButtonAnimator>();
    }
}
