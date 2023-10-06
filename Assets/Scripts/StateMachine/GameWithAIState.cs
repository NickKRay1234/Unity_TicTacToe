using MVP.TicTacToeView;
using UnityEngine;
using UnityEngine.UI;

public class GameWithAIState : MonoBehaviour, IState
{
    [SerializeField] private GameObject _headHUD;
    [SerializeField] private StateMachine _machine;
    private GridView _grid;
    private CommandInvoker _invoker;
    public void Enter()
    {
        _grid = ServiceLocator.Current.Get<GridView>();
        _grid.InitializeGrid();
        _invoker = ServiceLocator.Current.Get<CommandInvoker>();
        _invoker.IsGameWithAI = true;
        _headHUD.SetActive(true);
        gameObject.SetActive(true);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I entered in Game state</color>");
#endif
    }

    public void Exit()
    {
        _invoker = ServiceLocator.Current.Get<CommandInvoker>();
        _invoker.ClearStack();
        gameObject.SetActive(false);
        _headHUD.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I came out of my Game state</color>");
#endif
    }
}