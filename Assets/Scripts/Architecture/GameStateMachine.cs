using System;
using System.Collections.Generic;

namespace Architecture.Infrastructure
{
    // Класс GameStateMachine управляет состояниями игры.
    // Он содержит словарь доступных состояний и текущее активное состояние.
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        // В конструкторе инициализируется словарь состояний и загрузчик сцен,
        // который передается каждому состоянию.
        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, curtain),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        // Метод для перехода в определенное состояние.
        // Все состояния должны быть подтипом IState.
        public void Enter<TState>() where TState : class, IState => 
            ChangeState<TState>().Enter();


        // Получение определенного состояния из словаря состояний.
        private TState GetState<TState>() where TState : class, IExitableState
        {
            if (_states.TryGetValue(typeof(TState), out var state))
                return state as TState;

            throw new InvalidOperationException($"State of type {typeof(TState)} does not exist in the state machine.");
        }

        // Перегруженный метод для перехода в определенное состояние с передачей информации.
        // Все состояния должны быть подтипом IPayloadedState<TPayload>.
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload> => 
            ChangeState<TState>().Enter(payload);

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit(); // Вызов выхода из текущего активного состояния.
            TState state = GetState<TState>(); // Установка нового активного состояния.
            _activeState = state;
            return state;
        }
    }
}