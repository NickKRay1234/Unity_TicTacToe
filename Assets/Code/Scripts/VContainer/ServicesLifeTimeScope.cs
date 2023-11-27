using Architecture.Infrastructure;
using VContainer;
using VContainer.Unity;

public class ServicesLifeTimeScope : LifetimeScope
{
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<BootstrapState>(Lifetime.Scoped);
    }
}