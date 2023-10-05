using System;
using System.Collections.Generic;

namespace Architecture.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;
        
        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, curtain),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain),
            };
        }
        
        public void Enter<TState>() where TState : class, IState => 
            ChangeState<TState>().Enter();

        
        private TState GetState<TState>() where TState : class, IExitableState
        {
            if (_states.TryGetValue(typeof(TState), out var state))
                return state as TState;

            throw new InvalidOperationException($"State of type {typeof(TState)} does not exist in the state machine.");
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload> => 
            ChangeState<TState>().Enter(payload);

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }
    }
}