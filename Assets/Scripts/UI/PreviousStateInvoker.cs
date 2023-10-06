using UnityEngine;

public class PreviousStateInvoker : MonoBehaviour
{
    public void StartPreviousState()
    {
        StateMachine stateMachine = ServiceLocator.Current.Get<StateMachine>();
        stateMachine.ChangeState(stateMachine.PreviousState);
    }
}
