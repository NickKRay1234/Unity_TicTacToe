using Architecture.Infrastructure;
using UnityEngine;
using VContainer;
using VContainer.Unity;

[HelpURL("https://dev.to/clandais/unity-game-architecture-part-1-4a9j")]
public class ServicesLifeTimeScope : LifetimeScope
{
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<BootstrapState>(Lifetime.Scoped);
    }
}