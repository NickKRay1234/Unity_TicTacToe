public class ResultDemonstrator
{
    public void ShowResult(StateMachine stateMachine, IState state)
    {
        stateMachine.ChangeState(state);
    }
}