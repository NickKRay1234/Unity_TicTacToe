using System.Collections.Generic;
using MVP.Model;
using MVP.TicTacToeView;
using UnityEngine;

public class CommandInvoker : MonoBehaviour, IService
{
    private IGridCleanable _gridCleanable;
    private IReferee _referee;
    private IWinScreenDisplay _winScreen;
    public Stack<ICommand> UndoStack { get; } = new(DesignDataContainer.MAX_NUMBER_OF_MOVES);
    private int _oldCount;
    public bool IsGameWithAI;

    private void Update()
    {
#if UNITY_EDITOR
        if (UndoStack.Count == DesignDataContainer.MAX_NUMBER_OF_MOVES)
            Debug.Log($"<color=red>Stack is full. Game is over.</color>");
#endif
    }
    
    public void Execute(ICommand command)
    {
        _referee = ServiceLocator.Current.Get<Referee>();
        _winScreen = ServiceLocator.Current.Get<Referee>();
        command.Execute();
        UndoStack.Push(command);
        CheckGameStatusAndClearIfNecessary();
    }

    private void CheckGameStatusAndClearIfNecessary()
    {
        _referee.ShowLoseScreen(PlayerMark.X, IsGameWithAI);
            if(_referee.CheckWinAndShowWin(PlayerMark.X) || _referee.CheckWinAndShowWin(PlayerMark.O) || _referee.CheckDraw(PlayerMark.None))
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