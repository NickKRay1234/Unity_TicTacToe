using System.Collections.Generic;
using MVP.Model;
using UnityEngine;

public class CommandInvoker : MonoBehaviour, IService
{
    private const int MAX_NUMBER_OF_MOVES = 9;
    private const int STACK_COUNT_FOR_CHECKS = 5;
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
        DecisionMaker decision = ServiceLocator.Current.Get<DecisionMaker>();
        command.Execute();
        UndoStack.Push(command);
        if (UndoStack.Count is >= STACK_COUNT_FOR_CHECKS and <= MAX_NUMBER_OF_MOVES)
        {
            decision.CheckWin(PlayerMark.X);
            decision.CheckWin(PlayerMark.O);
            decision.CheckDraw();
        }

        if (decision.IsWin || decision.IsDraw)
        {
            ClearStack();
            decision.IsWin = false;
            decision.IsDraw = false;
        }
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

    public void ClearStack() => UndoStack.Clear();
}