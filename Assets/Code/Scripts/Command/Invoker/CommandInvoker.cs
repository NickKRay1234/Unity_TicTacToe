using System.Collections.Generic;
using MVP.Model;
using MVP.TicTacToeView;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

[HelpURL("https://unity.com/how-to/use-command-pattern-flexible-and-extensible-game-systems")]
public sealed class CommandInvoker : MonoBehaviour
{
    [Header("Buttons")] [SerializeField] private Button _undoButton;

    [Inject] private IGridCleanable _gridCleanable;
    [Inject] private IReferee _referee;

    public bool IsGameWithAI { get; set; }

    private static readonly Stack<ICommand> UndoStack =
        new(DesignDataContainer.MAX_NUMBER_OF_MOVES);

    private void Start() => _undoButton.onClick.AddListener(Undo);

    public void Execute(ICommand command)
    {
        command.Execute();
        UndoStack.Push(command); // Store command for potential undo action.
        if (IsGameEnded(IsGameWithAI)) ClearStack();
    }

    /// Determines if the game has ended
    public bool IsGameEnded(bool isGameWithAI) =>
        _referee.CheckWin(PlayerMark.X, isGameWithAI)
        || _referee.CheckWin(PlayerMark.O, isGameWithAI)
        || _referee.CheckDraw(PlayerMark.None);

    public void Undo()
    {
        if (UndoStack.Count <= 0) return;
        ICommand activeCommand = UndoStack.Pop();
        activeCommand.Undo();
    }

    public void ClearStack()
    {
        _gridCleanable.ClearGrid();
        UndoStack.Clear();
    }
}