using System;

namespace Architecture.Infrastructure
{
    // Класс, используется для инициализации или регистрации сервисов при старте игры.
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string Main = "Main";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadLevelState, string>(Main);

        private void RegisterServices()
        {
            Game.InputService = RegisterInputService();
        }

        public void Exit()
        {
        }
        
        public static IInputService RegisterInputService()
        {
            return null;
        }
    }
}