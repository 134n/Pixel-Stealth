using VContainer;
using VContainer.Unity;

public class TitleLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<TitleView>();
        builder.RegisterEntryPoint<TitleTop>();
        builder.RegisterEntryPoint<TitleButtonAnimator>();
    }
}
