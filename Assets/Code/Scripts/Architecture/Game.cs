namespace Architecture.Infrastructure
{
    /// Core class to initialize the game state machine.
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain) => StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner, loadingCurtain), loadingCurtain);
    }
}