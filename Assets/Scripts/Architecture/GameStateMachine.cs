using System;
using System.Collections.Generic;

namespace Architecture.Infrastructure
{
    // Класс GameStateMachine управляет состояниями игры.
    // Он содержит словарь доступных состояний и текущее активное состояние.
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IState> _states;
        private IState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
            };
        }
        
        // Метод для перехода в определенное состояние.
        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}


