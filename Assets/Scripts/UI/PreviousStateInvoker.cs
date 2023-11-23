using UnityEngine;
using UnityEngine.Advertisements;

public class PreviousStateInvoker : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private int _counter = 0;
    
    
    
    public void StartPreviousState()
    {
        _stateMachine.RevertToPreviousState();
        _counter++;
        if(_counter == 1) Advertisement.Initialize("b37736b2-6b4e-40b3-ab0b-34540ef65b05", true, this);
    }

    public void OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
