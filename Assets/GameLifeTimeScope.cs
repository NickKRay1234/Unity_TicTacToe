using MVP.Model;
using MVP.TicTacToeView;
using SignFactory;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private GridView _gridView;
    [SerializeField] private Referee _referee;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<IObjectResolver, Container>(Lifetime.Scoped);
        builder.Register<Cell_Factory>(Lifetime.Singleton);
        builder.Register<Scorekeeper>(Lifetime.Singleton);
        builder.Register<WinState>(Lifetime.Singleton);
        builder.Register<StateMachine>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<CellView>(Lifetime.Singleton).AsSelf();
        builder.Register<CommandInvoker>(Lifetime.Singleton).AsSelf();
        builder.Register<GameWithAIState>(Lifetime.Singleton).AsSelf();
        builder.RegisterComponent(_gridView).AsImplementedInterfaces().AsSelf();
        builder.RegisterComponent(_referee).AsImplementedInterfaces().AsSelf();
    }
}