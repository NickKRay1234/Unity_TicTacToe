using UnityEngine;

public class PreviousStateInvoker : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    public void StartPreviousState() => _stateMachine.RevertToPreviousState();
}
