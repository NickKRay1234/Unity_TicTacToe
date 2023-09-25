using MVP.Model;
using MVP.TicTacToeView;
using SignFactory;
using UnityEngine;

public class ServiceLocatorGameplay : MonoBehaviour
{
    [SerializeField] private CommandInvoker _commandInvoker;
    [SerializeField] private MiniMax _miniMax;
    [SerializeField] private Cell_Factory _cellFactory;
    [SerializeField] private Referee _referee;
    [SerializeField] private GridView _gridView;
    [SerializeField] private X_Factory _xFactory;
    [SerializeField] private O_Factory _oFactory;
    [SerializeField] private StateMachine _state;
    [SerializeField] private Scorekeeper _scorekeeper;
    private void Awake() => RegisterServices();
    
    private void RegisterServices()
    {
        ServiceLocator.Initialize();
        ServiceLocator.Current.Register(_commandInvoker);
        ServiceLocator.Current.Register(_scorekeeper);
        ServiceLocator.Current.Register(_miniMax);
        ServiceLocator.Current.Register(_cellFactory);
        ServiceLocator.Current.Register(_gridView);
        ServiceLocator.Current.Register(_xFactory);
        ServiceLocator.Current.Register(_oFactory);
        ServiceLocator.Current.Register(_state);
        ServiceLocator.Current.Register(_referee);
    }

    private void OnDestroy()
    {
        ServiceLocator.Current.Unregister<CommandInvoker>();
        ServiceLocator.Current.Unregister<Scorekeeper>();
        ServiceLocator.Current.Unregister<MiniMax>();
        ServiceLocator.Current.Unregister<Referee>();
        ServiceLocator.Current.Unregister<Cell_Factory>();
        ServiceLocator.Current.Unregister<StateMachine>();
        ServiceLocator.Current.Unregister<X_Factory>();
        ServiceLocator.Current.Unregister<O_Factory>();
        ServiceLocator.Current.Unregister<GridView>();
    }
}
