using System;
using MVP.Model;
using MVP.TicTacToePresenter;
using MVP.TicTacToeView;
using UnityEngine;

public class DecisionMaker : MonoBehaviour, IService
{
    [SerializeField] private GameObject _firstPlayerWinScreen;
    [SerializeField] private GameObject _secondPlayerWinScreen;
    [SerializeField] private GameObject _lose;
    [HideInInspector] public bool IsWin;
    [HideInInspector] public bool IsDraw;
    [HideInInspector] public PlayerMark Winner;
    private GridPresenter _presenter;
    private GridView _grid;
    private StateMachine _stateMachine;


    private void Start()
    {
        _grid = ServiceLocator.Current.Get<GridView>();
        _stateMachine = ServiceLocator.Current.Get<StateMachine>();
        _stateMachine.Initialize(_stateMachine.Start);
        Winner = PlayerMark.None;
    }

    private bool IsHorizontalWin(PlayerMark player)
    {
        _presenter = ServiceLocator.Current.Get<GridView>().GridPresenter;
        for (int i = 0; i < 3; i++)
            if (_presenter.Model.GridCells[i, 0].Player == player &&
                _presenter.Model.GridCells[i, 1].Player == player &&
                _presenter.Model.GridCells[i, 2].Player == player)
            {
#if UNITY_EDITOR
                Debug.Log($"<color=green>{player} won. Horizontal win.</color>");
#endif
                return true;
            }
        return false;
    }
    
    private bool IsVerticalWin(PlayerMark player)
    {
        _presenter = ServiceLocator.Current.Get<GridView>().GridPresenter;
        for (int j = 0; j < 3; j++)
            if (_presenter.Model.GridCells[0, j].Player == player &&
                _presenter.Model.GridCells[1, j].Player == player &&
                _presenter.Model.GridCells[2, j].Player == player)
            {
#if UNITY_EDITOR
                Debug.Log($"<color=green>{player} won. Vertical win.</color>");
#endif
                return true;
            }

        return false;
    }
    
    private bool IsDiagonalWin(PlayerMark player)
    {
        _presenter = ServiceLocator.Current.Get<GridView>().GridPresenter;
        if (_presenter.Model.GridCells[0, 0].Player == player &&
            _presenter.Model.GridCells[1, 1].Player == player &&
            _presenter.Model.GridCells[2, 2].Player == player)
        {
#if UNITY_EDITOR
            Debug.Log($"<color=green>{player} won. Diagonal win.</color>");
#endif
            return true;
        }
        
        if (_presenter.Model.GridCells[0, 2].Player == player && 
            _presenter.Model.GridCells[1, 1].Player == player && 
            _presenter.Model.GridCells[2, 0].Player == player)
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
        switch (player)
        {
            case PlayerMark.X:
                Winner = PlayerMark.X;
                _stateMachine.ChangeState(_stateMachine.Win);
                break;
            case PlayerMark.O:
                Winner = PlayerMark.O;
                _stateMachine.ChangeState(_stateMachine.Win);
                break;
            case PlayerMark.None:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(player), player, null);
        }
    }

    public void CheckWin(PlayerMark player)
    {
        if (IsHorizontalWin(player) || IsVerticalWin(player) || IsDiagonalWin(player))
        {
            IsWin = true;
            ShowWinScreen(player);
        }
    }

    public void CheckDraw()
    {
        _presenter = ServiceLocator.Current.Get<GridView>().GridPresenter;
        for (int i = 0; i < GridModel.GRID_SIZE; i++)
            for (int j = 0; j < GridModel.GRID_SIZE; j++)
                if (_presenter.Model.GridCells[i, j].Player == PlayerMark.None)
                    return;
        IsDraw = true;
        _stateMachine.ChangeState(_stateMachine.Draw);
    }
    
}
