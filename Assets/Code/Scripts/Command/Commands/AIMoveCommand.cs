using MVP.Model;
using MVP.TicTacToePresenter;
using UnityEngine;

[HelpURL("https://unity.com/how-to/use-command-pattern-flexible-and-extensible-game-systems")]
public sealed class AIMoveCommand : BaseCommand
{
    private readonly IAIStrategy _aiStrategy;
    private readonly GridPresenter _gridPresenter;

    public AIMoveCommand(CommandParameters parameters, GridPresenter gridPresenter, IAIStrategy aiStrategy) : base(parameters)
    {
        _gridPresenter = gridPresenter;
        _aiStrategy = aiStrategy;
    }

    public override void Execute()
    {
        CellModel bestMove = _aiStrategy.GetAvailableBestMove(_gridPresenter);
        if (bestMove == null) return;

        PlaceMoveOnBoard(bestMove);
        UpdateLastMove(bestMove);
    }

    /// Updates the last move information
    private void UpdateLastMove(CellModel move)
    {
        _lastMoveTransform = move.CellObject.transform;
        _lastMoveCell = move;
    }

    /// Places the mark on the board for the given move
    private void PlaceMoveOnBoard(CellModel move)
        => PlaceMarkAndHandleLastMove(move, GetPlayerMark(), move.CellObject.transform);

    /// Retrieves the player mark
    protected override PlayerMark GetPlayerMark() => PlayerMark.O;
}