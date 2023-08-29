using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour, IService
{
    private Stack<ICommand> _undoStack = new();

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