using UnityEngine;
using VContainer;

public class PreviousStateInvoker : MonoBehaviour
{
    [Inject] private StateMachine _stateMachine;
    public void StartPreviousState() => _stateMachine.RevertToPreviousState();
}
