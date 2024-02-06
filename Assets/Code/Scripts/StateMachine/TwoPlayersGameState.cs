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
        DesignDataContainer.IsGameWithAI = false;
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