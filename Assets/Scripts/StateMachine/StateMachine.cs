using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<GameStateType, IState> _states = new();
    
    [SerializeField] private TwoPlayersGameState _twoPlayersGame;
    [SerializeField] private GameWithAIState _gameWithAI;
    [SerializeField] private SelectGameState _select;
    [SerializeField] private StartState _start;
    [SerializeField] private DrawState _draw;
    [SerializeField] private LoseState _lose;
    [SerializeField] private BackState _back;
    [SerializeField] private WinState _win;
    private IState _previousState;
    
    public IState CurrentState { get; private set; }
    
    public DrawState Draw => _draw;
    public StartState Start => _start;
    public WinState Win => _win;
    public LoseState Lose => _lose;
    
    private void Awake()
    {
        _states[GameStateType.Start] = _start;
        _states[GameStateType.Draw] = _draw;
        _states[GameStateType.Lose] = _lose;
        _states[GameStateType.Win] = _win;
        _states[GameStateType.Select] = _select;
        _states[GameStateType.GameWithAI] = _gameWithAI;
        _states[GameStateType.TwoPlayersGame] = _twoPlayersGame;
    }
    
    /// Switches the state machine to the specified state type.
    public void SwitchState(GameStateType stateType) => ChangeState(stateType);
    
    public void SwitchState(){}
    
    
    /// Initialises the state machine with the initial state.
    public void Initialize(IState startState)
    {
        CurrentState = startState;
        CurrentState?.Enter();
    }
    
    /// Changes the current state to the specified state type.
    public void ChangeState(GameStateType newStateType)
    {
        if (!_states.ContainsKey(newStateType))
        {
#if UNITY_EDITOR
            Debug.LogError($"State {newStateType} not found!");
#endif
            return;
        }

        _previousState = CurrentState;
        CurrentState?.Exit();
        CurrentState = _states[newStateType];
        CurrentState?.Enter();
    }
    
    /// Changes the current state to the specified state.
    public void ChangeState(IState newState)
    {
        if (newState == null)
        {
#if UNITY_EDITOR
            Debug.LogError("Provided new state is null!");
#endif
            return;
        }
        
        _previousState = CurrentState;
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }
    
    /// Returns the state machine to the previous state.
    public void RevertToPreviousState()
    {
        if (_previousState == null)
        {
#if UNITY_EDITOR
            Debug.LogWarning("No previous state to revert to.");
#endif
            return;
        }
        ChangeState(_previousState);
    }
}