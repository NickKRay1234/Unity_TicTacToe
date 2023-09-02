using MVP.TicTacToeView;
using UnityEngine;

public class GameState : MonoBehaviour, IState
{
    private GridView _grid;
    public void Enter()
    {
        _grid = ServiceLocator.Current.Get<GridView>();
        _grid.InitializeGrid();
        gameObject.SetActive(true);
#if UNITY_EDITOR
        Debug.Log("I entered in Start state");
#endif
    }

    public void Exit()
    {
        _grid = ServiceLocator.Current.Get<GridView>();
        gameObject.SetActive(false);
        _grid.Dispose();
#if UNITY_EDITOR
        Debug.Log("I came out of my Start state");
#endif
    }
}