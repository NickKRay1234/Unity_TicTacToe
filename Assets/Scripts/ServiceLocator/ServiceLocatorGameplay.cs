using SignFactory;
using UnityEngine;

public class ServiceLocatorGameplay : MonoBehaviour
{
    [SerializeField] private StateMachine _state;
    
    private void Awake() => RegisterServices();
    
    private void RegisterServices()
    {
        ServiceLocator.Initialize();
        ServiceLocator.Current.Register(DesignDataContainer.GlobalXFactory);
        ServiceLocator.Current.Register(DesignDataContainer.GlobalOFactory);
        ServiceLocator.Current.Register(_state);
    }

    private void OnDestroy()
    {
        ServiceLocator.Current.Unregister<StateMachine>();
        ServiceLocator.Current.Unregister<X_Factory>();
        ServiceLocator.Current.Unregister<O_Factory>();
    }
}
