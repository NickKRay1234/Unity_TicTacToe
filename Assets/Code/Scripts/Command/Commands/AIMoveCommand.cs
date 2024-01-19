using System;
using MVP.Model;
using SignFactory;
using UnityEngine;

[HelpURL("https://unity.com/how-to/use-command-pattern-flexible-and-extensible-game-systems")]
public sealed class AIMoveCommand : BaseCommand
{
    private readonly HeuristicAI _heuristicAI;

    public AIMoveCommand(CommandParameters parameters, HeuristicAI heuristicAI) : base(parameters) =>
        _heuristicAI = heuristicAI;

    public override void Execute()
    {
        CellModel bestMove = GetBestMove();
        if (bestMove == null) return;

        PlaceMoveOnBoard(bestMove);
        UpdateLastMove(bestMove);
    }

    /// Gets the best available move from the AI
    private CellModel GetBestMove()
        => _heuristicAI.GetAvailableBestMove();

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