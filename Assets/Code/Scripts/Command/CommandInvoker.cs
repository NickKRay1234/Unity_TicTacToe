using System.Collections.Generic;
using MVP.Model;
using MVP.TicTacToeView;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

[HelpURL("https://unity.com/how-to/use-command-pattern-flexible-and-extensible-game-systems")]
public sealed class CommandInvoker : MonoBehaviour
{
    [Header("Buttons")] 
    [SerializeField] private Button _undoButton;
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
        ClearIfGameEnded();
    }

    private bool CheckGameStatus() =>
        _referee.CheckWin(PlayerMark.X, IsGameWithAI) || _referee.CheckWin(PlayerMark.O, IsGameWithAI) || _referee.CheckDraw(PlayerMark.None);

    public void ClearIfGameEnded()
    {
        if (CheckGameStatus()) 
            ClearStack();
    }

    public void Undo()
    {
        if (UndoStack.Count > 0)
        {
            ICommand activeCommand = UndoStack.Pop();
            activeCommand.Undo();
        }
    }

    public void ClearStack()
    {
        _gridCleanable.Clear();
        UndoStack.Clear();
    }
}