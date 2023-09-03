using System.Collections.Generic;
using MVP.Model;
using MVP.TicTacToeView;
using UnityEngine;

public class CommandInvoker : MonoBehaviour, IService
{
    private const int MAX_NUMBER_OF_MOVES = 9;
    private const int STACK_COUNT_FOR_CHECKS = 5;
    private IGridCleanable _gridCleanable;
    private IReferee _referee;
    public Stack<ICommand> UndoStack { get; } = new(MAX_NUMBER_OF_MOVES);

    private void Update()
    {
#if UNITY_EDITOR
        if (UndoStack.Count == MAX_NUMBER_OF_MOVES)
            Debug.Log($"<color=red>Stack is full. Game is over.</color>");
#endif
    }
    
    public void Execute(ICommand command)
    {
        _referee = ServiceLocator.Current.Get<Referee>();
        command.Execute();
        UndoStack.Push(command);
        CheckGameStatusAndClearIfNecessary();
    }

    private void CheckGameStatusAndClearIfNecessary()
    {
        if (UndoStack.Count is >= STACK_COUNT_FOR_CHECKS and <= MAX_NUMBER_OF_MOVES)
            if(_referee.CheckWin(PlayerMark.X) || _referee.CheckWin(PlayerMark.O) || _referee.CheckDraw(PlayerMark.None))
                ClearStack();
    }

    public void Undo()
    {
        if (UndoStack.Count > 0)
        {
            ICommand activeCommand = UndoStack.Pop();
            activeCommand.Undo();
            return;
        }
        
#if UNITY_EDITOR
        if(UndoStack.Count == 0)
            Debug.Log($"<color=red>Stack is empty</color>");
#endif
    }

    public void ClearStack()
    {
        _gridCleanable = ServiceLocator.Current.Get<GridView>();
        _gridCleanable.Clear();
        UndoStack.Clear();
    }
}