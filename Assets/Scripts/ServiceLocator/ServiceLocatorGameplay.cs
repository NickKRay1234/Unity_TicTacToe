using MVP.TicTacToeView;
using SignFactory;
using UnityEngine;
using UnityEngine.Serialization;

public class ServiceLocatorGameplay : MonoBehaviour
{
    [SerializeField] private CommandInvoker _commandInvoker;
    [SerializeField] private DecisionMaker _decisionMaker;
    [SerializeField] private GridView _gridView;
    [SerializeField] private X_Factory _xFactory;
    [SerializeField] private O_Factory _oFactory;
    [SerializeField] private StateMachine _state;
    private void Awake() => RegisterServices();
    
    private void RegisterServices()
    {
        ServiceLocator.Initialize();
        ServiceLocator.Current.Register(_commandInvoker);
        ServiceLocator.Current.Register(_gridView);
        ServiceLocator.Current.Register(_xFactory);
        ServiceLocator.Current.Register(_oFactory);
        ServiceLocator.Current.Register(_state);
        ServiceLocator.Current.Register(_decisionMaker);
    }

    private void OnDestroy()
    {
        ServiceLocator.Current.Unregister<CommandInvoker>();
        ServiceLocator.Current.Unregister<DecisionMaker>();
        ServiceLocator.Current.Unregister<StateMachine>();
        ServiceLocator.Current.Unregister<X_Factory>();
        ServiceLocator.Current.Unregister<O_Factory>();
        ServiceLocator.Current.Unregister<GridView>();
    }
}
