using UnityEngine;
using VContainer;
using VContainer.Unity;


public class MenuLifetimeScope : LifetimeScope
{
    [SerializeField] private Menu menu;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);
        builder.RegisterComponent(menu);
    }
}
