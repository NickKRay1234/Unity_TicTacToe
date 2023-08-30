using System.Collections.Generic;
using MVP.Model;
using UnityEngine;

public class CommandInvoker : MonoBehaviour, IService
{
    private const int MAX_NUMBER_OF_MOVES = 9;
    public Stack<ICommand> UndoStack { get; } = new(MAX_NUMBER_OF_MOVES);


    private void Update()
    {
        
        if (UndoStack.Count == MAX_NUMBER_OF_MOVES)
#if UNITY_EDITOR
            Debug.Log($"<color=red>Stack is full. Game is over.</color>");
#endif
    }
    

    public void Execute(ICommand command)
    {
        DecisionMaker decision = ServiceLocator.Current.Get<DecisionMaker>();
        command.Execute();
        UndoStack.Push(command);
        decision.CheckWin(PlayerMark.X);
    }


    public void Undo()
    {
        if (UndoStack.Count > 0)
        {
            ICommand activeCommand = UndoStack.Pop();
            activeCommand.Undo();
            return;
        }
        
        if(UndoStack.Count == 0)
#if UNITY_EDITOR
            Debug.Log($"<color=red>Stack is empty</color>");
#endif
    }

    public void ClearStack() => UndoStack.Clear();
}