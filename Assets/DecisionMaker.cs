using System;
using MVP.Model;
using MVP.TicTacToePresenter;
using MVP.TicTacToeView;
using UnityEngine;

public class DecisionMaker : MonoBehaviour, IService
{
    [SerializeField] private GameObject _firstPlayerWinScreen;
    [SerializeField] private GameObject _secondPlayerWinScreen;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _lose;
    [SerializeField] private GameObject _draw;
    private GridView _grid;


    private void Start() => _grid = ServiceLocator.Current.Get<GridView>();

    private bool IsHorizontalWin(GridPresenter presenter, PlayerMark player)
    {
        for (int i = 0; i < 3; i++)
            if (presenter.Model.GridCells[i, 0].Player == player &&
                presenter.Model.GridCells[i, 1].Player == player &&
                presenter.Model.GridCells[i, 2].Player == player)
            {
#if UNITY_EDITOR
                Debug.Log($"<color=green>{player} won. Horizontal win.</color>");
#endif
                return true;
            }
        return false;

    }
    
    private bool IsVerticalWin(GridPresenter presenter, PlayerMark player)
    {
        for (int j = 0; j < 3; j++)
            if (presenter.Model.GridCells[0, j].Player == player &&
                presenter.Model.GridCells[1, j].Player == player &&
                presenter.Model.GridCells[2, j].Player == player)
            {
#if UNITY_EDITOR
                Debug.Log($"<color=green>{player} won. Vertical win.</color>");
#endif
                return true;
            }

        return false;
    }
    
    private bool IsDiagonalWin(GridPresenter presenter, PlayerMark player)
    {
        if (presenter.Model.GridCells[0, 0].Player == player &&
            presenter.Model.GridCells[1, 1].Player == player &&
            presenter.Model.GridCells[2, 2].Player == player)
        {
#if UNITY_EDITOR
            Debug.Log($"<color=green>{player} won. Diagonal win.</color>");
#endif
            return true;
        }
        
        if (presenter.Model.GridCells[0, 2].Player == player && 
            presenter.Model.GridCells[1, 1].Player == player && 
            presenter.Model.GridCells[2, 0].Player == player)
        {
#if UNITY_EDITOR
            Debug.Log($"<color=green>{player} won. Diagonal win.</color>");
#endif
            return true;
        }
        return false;
    }

    private void ShowWinScreen(PlayerMark player)
    {
        if (player == PlayerMark.X)
            _firstPlayerWinScreen.SetActive(true);
        _game.SetActive(false);
        _grid.Dispose();
    }
    


    public void CheckWin(PlayerMark player)
    {
        GridPresenter presenter = ServiceLocator.Current.Get<GridView>().GridPresenter;
        if (presenter == null) return;

        if (IsHorizontalWin(presenter, player) || IsVerticalWin(presenter, player) || IsDiagonalWin(presenter, player))
            ShowWinScreen(player);
    }
    
}