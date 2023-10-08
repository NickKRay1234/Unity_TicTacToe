using System.Collections.Generic;
using MVP.Model;
using MVP.TicTacToeView;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class CommandInvoker : MonoBehaviour
{
    [Header("Buttons")] 
    [SerializeField] private Button _undoButton;
    public bool IsGameWithAI { get; set; }
    [Inject] private IGridCleanable _gridCleanable;
    [Inject] private IReferee _referee;

    public static Stack<ICommand> UndoStack { get; } = new(DesignDataContainer.MAX_NUMBER_OF_MOVES);
    private void Start() => _undoButton.onClick.AddListener(Undo);

    private void Update()
    {
#if UNITY_EDITOR
        if (UndoStack.Count == DesignDataContainer.MAX_NUMBER_OF_MOVES)
            Debug.Log($"<color=red>Stack is full. Game is over.</color>");
#endif
    }

    public void Execute(ICommand command)
    {
        command.Execute();
        UndoStack.Push(command);
        CheckGameStatusAndClearIfNecessary();
    }

    private void CheckGameStatusAndClearIfNecessary()
    {
        if (_referee.CheckWin(PlayerMark.X) || _referee.CheckWin(PlayerMark.O) || _referee.CheckDraw(PlayerMark.None))
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

        if (UndoStack.Count == 0)
        {
#if UNITY_EDITOR
            Debug.Log($"<color=red>Stack is empty</color>");
#endif
        }
    }

    public void ClearStack()
    {
        _gridCleanable.Clear();
        UndoStack.Clear();
    }
}