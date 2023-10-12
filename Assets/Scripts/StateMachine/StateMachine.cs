using UnityEngine;

public class StateMachine : MonoBehaviour
{

    [SerializeField] private TwoPlayersGameState _twoPlayersGame;
    [SerializeField] private GameWithAIState _gameWithAI;
    [SerializeField] private SelectGameState _select;
    [SerializeField] private StartState _startingState;
    [SerializeField] private ShopState _shopState;
    [SerializeField] private DrawState _draw;
    [SerializeField] private LoseState _lose;
    [SerializeField] private BackState _back;
    [SerializeField] private WinState _win;
    private IState _previousState;
    public IState CurrentState { get; private set; }
    public StartState StartingState => _startingState;
    public DrawState Draw => _draw;
    public WinState Win => _win;
    public LoseState Lose => _lose;
    
    public void SwitchToTwoPlayersGameState() => ChangeState(_twoPlayersGame);
    public void SwitchToGameWithAIState() => ChangeState(_gameWithAI);
    public void SwitchToSelectGameState() => ChangeState(_select);
    public void SwitchToStartState() => ChangeState(_startingState);
    public void SwitchToDrawState() => ChangeState(_draw);
    public void SwitchToLoseState() => ChangeState(_lose);
    public void SwitchToBackState() => ChangeState(_back);
    public void SwitchToWinState() => ChangeState(_win);
    public void SwitchToShopState() => ChangeState(_shopState);
    
    
    /// Initialises the state machine with the initial state.
    public void Initialize(IState state)
    {
        CurrentState = state;
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