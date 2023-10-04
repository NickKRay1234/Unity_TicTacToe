using System;
using MVP.Model;
using MVP.TicTacToePresenter;
using MVP.TicTacToeView;
using UnityEngine;

public class Referee : MonoBehaviour, IReferee, IWinScreenDisplay
{
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _lose;
    [SerializeField] private Scorekeeper _scorekeeper;
    [HideInInspector] public PlayerMark Winner;
    
    private GridPresenter _presenter;
    private GridView _grid;
    private StateMachine _stateMachine;
    public Action ScoreChanged;


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
                _presenter.Model.GridCells[i, 2].Player == player){
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
                _presenter.Model.GridCells[2, j].Player == player){
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
            _presenter.Model.GridCells[2, 2].Player == player){
#if UNITY_EDITOR
            Debug.Log($"<color=green>{player} won. Diagonal win.</color>");
#endif
            return true;
        }
        
        if (_presenter.Model.GridCells[0, 2].Player == player && 
            _presenter.Model.GridCells[1, 1].Player == player && 
            _presenter.Model.GridCells[2, 0].Player == player){
#if UNITY_EDITOR
            Debug.Log($"<color=green>{player} won. Diagonal win.</color>");
#endif
            return true;
        }
        return false;
    }
    
    public bool CheckWinAndShowWin(PlayerMark player)
    {
        if (IsWin(player))
        {
            ShowWinScreen(player);
            return true;
        }
        return false;
    }
    
    public bool ShowLoseScreen(PlayerMark player, bool IsAI)
    {
        if (IsAIWin(player, IsAI))
        {
            SetResult(PlayerMark.X, _stateMachine.Lose);
            return true;
        }
        return false;
    }
    
    public bool IsWin(PlayerMark player) =>
        IsHorizontalWin(player) || IsVerticalWin(player) || IsDiagonalWin(player);

    public bool IsAIWin(PlayerMark player, bool IsAI)
    {
        if (IsAI)
            return IsHorizontalWin(player) || IsVerticalWin(player) || IsDiagonalWin(player);
        return false;
    }


    public void ShowWinScreen(PlayerMark player)
    {
        switch (player)
        {
            case PlayerMark.X:
                SetResult(PlayerMark.X, _stateMachine.Win);
                break;
            case PlayerMark.O:
                SetResult(PlayerMark.O, _stateMachine.Win);
                break;
        }
    }

    public bool CheckDraw(PlayerMark player)
    {
        _presenter = ServiceLocator.Current.Get<GridView>().GridPresenter;
        for (int i = 0; i < GridModel.GRID_SIZE; i++)
            for (int j = 0; j < GridModel.GRID_SIZE; j++)
                if (_presenter.Model.GridCells[i, j].Player == player)
                    return false;
        SetResult(player, _stateMachine.Draw);
        return true;
    }

    private void SetResult(PlayerMark player, IState state)
    {
        Winner = player;
        ScoreChanged?.Invoke();
        _stateMachine.ChangeState(state);
        Winner = PlayerMark.None;
    }
}
