using UnityEngine;

public class PreviousStateInvoker : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private int _counter = 0;
    
    
    
    public void StartPreviousState()
    {
        _stateMachine.RevertToPreviousState();
        _counter++;
    }
}
