using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour, IService
{
    private Stack<ICommand> undoStack = new();

    public void Execute(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
    }


    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            ICommand activeCommand = undoStack.Pop();
            activeCommand.Undo();
        }
    }
}