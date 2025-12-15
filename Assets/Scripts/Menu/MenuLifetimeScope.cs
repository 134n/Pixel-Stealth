using VContainer;
using VContainer.Unity;

public class MenuLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<Menu>();

        builder.RegisterComponentInHierarchy<MenuButtonView>()
            .As<IMenuButtonView>();
        builder.RegisterEntryPoint<MenuButtonPresenter>();
        builder.Register<MenuButtonService>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<VolumeView>()
            .As<IVolumeView>();
        builder.RegisterEntryPoint<VolumePresenter>();
        builder.Register<AudioSettingService>(Lifetime.Singleton);
    }
}
