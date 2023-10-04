using UnityEngine;
using UnityEngine.Serialization;

public class StateMachine : MonoBehaviour, IService
{
    [SerializeField] private DrawState _draw;
    [SerializeField] private TwoPlayersGameState _twoPlayersGame;
    [SerializeField] private GameWithAIState _gameWithAI;
    [SerializeField] private StartState _start;
    [SerializeField] private WinState _win;
    [SerializeField] private LoseState _lose;
    [SerializeField] private BackState _back;
    [SerializeField] private SelectGameState _select;

    public BackState Back => _back;
    public DrawState Draw => _draw;
    public TwoPlayersGameState TwoPlayersGame => _twoPlayersGame;
    public GameWithAIState GameWithAI => _gameWithAI;
    public StartState Start => _start;
    public WinState Win => _win;
    public SelectGameState Select => _select;
    public LoseState Lose => _lose;

    public void SwitchOnTwoPlayersGame() => ChangeState(TwoPlayersGame);
    public void SwitchOnGameWithAI() => ChangeState(GameWithAI);
    public void SwitchOnSelectGameState() => ChangeState(Select);


    public IState CurrentState { get; set; }

    public void Initialize(IState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(IState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}