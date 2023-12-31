﻿namespace Architecture.Infrastructure
{
    /// State to handle the loading of different levels.
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }
        
        private void OnLoaded() { }
        public void Exit() { }
    }
}