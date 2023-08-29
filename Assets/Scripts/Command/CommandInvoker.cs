using System.Collections.Generic;
using MVP.Model;
using MVP.TicTacToePresenter;
using MVP.TicTacToeView;
using UnityEngine;

public class CommandInvoker : MonoBehaviour, IService
{
    private const int MAX_NUMBER_OF_MOVES = 9;
    private const int START_NUMBER_FOR_VICTORY_CHECK = 5;
    private Stack<ICommand> _undoStack = new(MAX_NUMBER_OF_MOVES);


    private void Update()
    {
        if(_undoStack.Count == START_NUMBER_FOR_VICTORY_CHECK)
        {
            if (IsWin(PlayerMark.O) || IsWin(PlayerMark.X))
            {
                return;
            }
        }
        
        if (_undoStack.Count == MAX_NUMBER_OF_MOVES)
#if UNITY_EDITOR
            Debug.Log($"<color=red>Stack is full. Game is over.</color>");
#endif
    }

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
    
    


    public bool IsWin(PlayerMark player)
    {
        GridPresenter presenter = ServiceLocator.Current.Get<GridView>().GridPresenter;
        return IsHorizontalWin(presenter, player) || IsVerticalWin(presenter, player) || IsDiagonalWin(presenter, player);
    }
    

    public void Execute(ICommand command)
    {
        command.Execute();
        _undoStack.Push(command);
    }


    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            ICommand activeCommand = _undoStack.Pop();
            activeCommand.Undo();
            return;
        }
        
        if(_undoStack.Count == 0)
#if UNITY_EDITOR
            Debug.Log($"<color=red>Stack is empty</color>");
#endif
    }
}