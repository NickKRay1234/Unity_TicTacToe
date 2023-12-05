namespace Architecture.Infrastructure
{
    
    /// BootstrapState: Initializes the game and loads the initial scene.
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;


        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter() =>
            _sceneLoader.Load(DesignDataContainer.Initial, onLoaded: EnterLoadLevel);

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadLevelState, string>(DesignDataContainer.Main);

        void IExitableState.Exit() { }
    }
}