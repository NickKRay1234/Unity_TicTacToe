namespace Architecture.Infrastructure
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}