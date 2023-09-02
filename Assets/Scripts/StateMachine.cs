using UnityEngine;

public class StateMachine : MonoBehaviour, IService
{
    [SerializeField] private DrawState _draw;
    [SerializeField] private GameState _game;
    [SerializeField] private StartState _start;

    public DrawState Draw => _draw;
    public GameState Game => _game;
    public StartState Start => _start;

    public void SwitchOnGame() => ChangeState(Game);


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