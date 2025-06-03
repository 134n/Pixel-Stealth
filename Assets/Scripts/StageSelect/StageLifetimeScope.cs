using VContainer;
using VContainer.Unity;

public class StageLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);
        builder.Register<StageSelectService>(Lifetime.Singleton);
        builder.RegisterEntryPoint<StageSelectPresenter>();
        builder.RegisterComponentInHierarchy<StageSelectButton>();
        
        builder.RegisterEntryPoint<StageSelectAnimator>();
    }
}
