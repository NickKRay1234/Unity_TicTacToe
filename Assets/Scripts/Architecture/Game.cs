namespace Architecture.Infrastructure
{
    // Класс Game представляет основной объект игры.
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain) => StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner, loadingCurtain), loadingCurtain);
    }
}