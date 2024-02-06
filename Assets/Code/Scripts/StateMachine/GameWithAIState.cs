using MVP.TicTacToeView;
using UnityEngine;
using VContainer;

public class GameWithAIState : MonoBehaviour, IState
{
    [SerializeField] private GridView _grid;
    [SerializeField] private GameObject _headHUD;
    [SerializeField] private StateMachine _machine;
    [Inject] private CommandInvoker _invoker;
    public void Enter()
    {
        _grid.InitializeGrid();
        DesignDataContainer.IsGameWithAI = true;
        _headHUD.SetActive(true);
        gameObject.SetActive(true);
    }

    public void Exit()
    {
        _invoker.ClearStack();
        gameObject.SetActive(false);
        _headHUD.SetActive(false);
    }
}