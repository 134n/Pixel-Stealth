using UnityEngine;
using VContainer;
using VContainer.Unity;

public class StageLifetimeScope : LifetimeScope
{
    [SerializeField] private StageSelect stageSelect;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScreenChange>(Lifetime.Singleton);
        builder.RegisterComponent(stageSelect);
    }
}
