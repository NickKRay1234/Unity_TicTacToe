using MVP.TicTacToeView;
using UnityEngine;
using VContainer;

public class TwoPlayersGameState : MonoBehaviour, IState
{
    [SerializeField] private GridView _grid;
    [SerializeField] private GameObject _headHUD;
    [Inject] private CommandInvoker _invoker;
    public void Enter()
    {
        _grid.InitializeGrid();
        _invoker.IsGameWithAI = false;
        _headHUD.SetActive(true);
        gameObject.SetActive(true);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I entered in Game state</color>");
#endif
    }

    public void Exit()
    {
        _invoker.ClearStack();
        gameObject.SetActive(false);
        _headHUD.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I came out of my Game state</color>");
#endif
    }
}