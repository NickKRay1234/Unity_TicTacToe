public class ResultDemonstrator
{
    public void ShowResult(IState state)
    {
        StateMachine _stateMachine = ServiceLocator.Current.Get<StateMachine>();
        _stateMachine.ChangeState(state);
    }
}