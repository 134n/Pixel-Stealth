using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TitleLifetimeScope : LifetimeScope
{
    [SerializeField] private TitleTop titleTop;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);
        builder.RegisterComponent(titleTop);
    }
}
