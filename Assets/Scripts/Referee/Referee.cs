using System;
using MVP.Model;
using MVP.TicTacToePresenter;
using MVP.TicTacToeView;
using UnityEngine;
using VContainer;

public class Referee : MonoBehaviour, IReferee
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private Scorekeeper _scorekeeper;
    
    [Inject] private DesignDataContainer _designDataContainer;
    [Inject] private GridView _grid;
    
    [HideInInspector] public PlayerMark PlayerMarkResult;
    
    private ResultDemonstrator _demonstrator;
    private GridPresenter _basePresenter;

    public IState StateResult { get; private set; }
    public Action ScoreChanged;


    private void Start()
    {
        _demonstrator = new ResultDemonstrator();
        _stateMachine.Initialize(_stateMachine.Start);
        PlayerMarkResult = PlayerMark.None;
    }

    private bool IsHorizontalWin(PlayerMark player)
    {
        _basePresenter = _grid.Presenter;
        for (int i = 0; i < 3; i++)
            if (_basePresenter.Model.GridCells[i, 0].OccupyingPlayer == player &&
                _basePresenter.Model.GridCells[i, 1].OccupyingPlayer == player &&
                _basePresenter.Model.GridCells[i, 2].OccupyingPlayer == player){
                return true;
            }
        return false;
    }
    
    private bool IsVerticalWin(PlayerMark player)
    {
        _basePresenter = _grid.Presenter;
        for (int j = 0; j < 3; j++)
            if (_basePresenter.Model.GridCells[0, j].OccupyingPlayer == player &&
                _basePresenter.Model.GridCells[1, j].OccupyingPlayer == player &&
                _basePresenter.Model.GridCells[2, j].OccupyingPlayer == player){
                return true;
            }
        return false;
    }
    
    private bool IsDiagonalWin(PlayerMark player)
    {
        _basePresenter = _grid.Presenter;
        if (_basePresenter.Model.GridCells[0, 0].OccupyingPlayer == player &&
            _basePresenter.Model.GridCells[1, 1].OccupyingPlayer == player &&
            _basePresenter.Model.GridCells[2, 2].OccupyingPlayer == player){
            return true;
        }
        
        return _basePresenter.Model.GridCells[0, 2].OccupyingPlayer == player && 
               _basePresenter.Model.GridCells[1, 1].OccupyingPlayer == player && 
               _basePresenter.Model.GridCells[2, 0].OccupyingPlayer == player;
    }
    
    public bool CanBeWin(PlayerMark player) => IsHorizontalWin(player) || IsVerticalWin(player) || IsDiagonalWin(player);
    
    public bool CheckWin(PlayerMark player)
    {
        if (IsHorizontalWin(player) || IsVerticalWin(player) || IsDiagonalWin(player))
        {
            DeclareResult(player, _stateMachine.Win);
            return true;
        }
        return false;
    }

    public bool CheckDraw(PlayerMark player)
    {
        _basePresenter = _grid.Presenter;
        for (int i = 0; i < _designDataContainer.GRID_SIZE; i++)
            for (int j = 0; j < _designDataContainer.GRID_SIZE; j++)
                if (_basePresenter.Model.GridCells[i, j].OccupyingPlayer == player)
                    return false;
        DeclareResult(player, _stateMachine.Draw);
        return true;
    }

    private void DeclareResult(PlayerMark player, IState state)
    {
        PlayerMarkResult = player;
        ScoreChanged?.Invoke();
        StateResult = state;
        _demonstrator.ShowResult(StateResult);
        PlayerMarkResult = PlayerMark.None;
    }
}