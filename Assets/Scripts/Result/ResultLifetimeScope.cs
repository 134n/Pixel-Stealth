using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ResultLifetimeScope : LifetimeScope
{
    [SerializeField] private ResultTop resultTop;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);
        builder.RegisterComponent(resultTop);
    }
}
