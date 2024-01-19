using MVP.Model;
using MVP.TicTacToeView;
using SignFactory;
using UnityEngine;
using VContainer;
using VContainer.Unity;

[HelpURL("https://dev.to/clandais/unity-game-architecture-part-1-4a9j")]
public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private GridView _gridView;
    [SerializeField] private Referee _referee;

    [SerializeField] private DesignDataContainer _designDataContainer;
    [SerializeField] private UIDesignDataContainer _uiDesignDataContainer;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_designDataContainer);
        builder.RegisterInstance(_uiDesignDataContainer);
        builder.Register<HeuristicAI>(Lifetime.Singleton);
        builder.Register<IObjectResolver, Container>(Lifetime.Scoped);
        builder.Register<GridModel>(Lifetime.Singleton).WithParameter(_designDataContainer.GRID_SIZE);
        builder.Register<BaseCommand>(Lifetime.Singleton).WithParameter(_designDataContainer);
        builder.Register<Factory>(Lifetime.Singleton);
        builder.Register<X_Factory>(Lifetime.Singleton).AsSelf();
        builder.Register<O_Factory>(Lifetime.Singleton).AsSelf();
        builder.Register<Cell_Factory>(Lifetime.Singleton);
        builder.Register<Scorekeeper>(Lifetime.Singleton);
        builder.Register<WinState>(Lifetime.Singleton);
        builder.Register<StateMachine>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<CommandInvoker>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<CellView>(Lifetime.Singleton).AsSelf();
        builder.Register<GameWithAIState>(Lifetime.Singleton).AsSelf();
        builder.RegisterComponent(_gridView).AsImplementedInterfaces().AsSelf();
        builder.RegisterComponent(_referee).AsImplementedInterfaces().AsSelf();
    }
}