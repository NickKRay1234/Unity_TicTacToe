using System;
using System.Collections.Generic;
using MVP.Model;
using MVP.TicTacToePresenter;

public sealed class MinMaxStrategyAI : BaseStrategyAI
{
    /// Finds the best move by evaluating all possible moves using the MinMax algorithm.
    private CellModel GetBestMove(CellModel[,] gridModels, PlayerMark currentPlayer)
    {
        int bestValue = MIN_SCORE;
        CellModel bestMove = null;

        foreach (var cell in GetAllEmptyCells(gridModels))
        {
            int moveValue = EvaluateMove(cell, currentPlayer, gridModels);
            if (moveValue > bestValue)
            {
                bestMove = cell;
                bestValue = moveValue;
            }
        }
        return bestMove;
    }
    
    /// Evaluates the score of a specific move.
    private int EvaluateMove(CellModel cell, PlayerMark currentPlayer, CellModel[,] gridModels)
    {
        cell.OccupyingPlayer = currentPlayer;
        int moveScore = MinMax(gridModels, 0, false, currentPlayer);
        cell.OccupyingPlayer = PlayerMark.None;
        return moveScore;
    }
    
    /// Recursive MinMax function for evaluating all possible moves.
    private int MinMax(CellModel[,] gridModels, int depth, bool isMaximizing, PlayerMark player)
    {
        int score = EvaluateBoard(gridModels, player);
        if (score is MAX_SCORE or MIN_SCORE || !IsMovesLeft(gridModels)) return score;
        return isMaximizing ? FindMaxScore(gridModels, player, depth) : FindMinScore(gridModels, player, depth);
    }

    private int FindMaxScore(CellModel[,] gridModels, PlayerMark player, int depth)
    {
        int bestScore = MIN_SCORE;
        foreach (var cell in GetAllEmptyCells(gridModels))
        {
            UpdateCell(cell, player);
            bestScore = Math.Max(bestScore, MinMax(gridModels, depth + 1, false, GetOpponent(player)));
            ResetCell(cell);
        }
        return bestScore;
    }

    private int FindMinScore(CellModel[,] gridModels, PlayerMark player, int depth)
    {
        int bestScore = MAX_SCORE;
        foreach (var cell in GetAllEmptyCells(gridModels))
        {
            UpdateCell(cell, player);
            bestScore = Math.Min(bestScore, MinMax(gridModels, depth + 1, true, GetOpponent(player)));
            ResetCell(cell);
        }
        return bestScore;
    }

    private void UpdateCell(CellModel cell, PlayerMark player) => cell.OccupyingPlayer = player;
    private void ResetCell(CellModel cell) => cell.OccupyingPlayer = PlayerMark.None;

    private int EvaluateBoard(CellModel[,] gridModels, PlayerMark player)
    {
        if (CheckWin(gridModels, player)) return MAX_SCORE;
        return CheckWin(gridModels, GetOpponent(player)) ? MIN_SCORE : 0;
    }

    private IEnumerable<CellModel> GetAllEmptyCells(CellModel[,] gridModels)
    {
        for (int i = 0; i < gridModels.GetLength(0); i++)
            for (int j = 0; j < gridModels.GetLength(1); j++)
                if (gridModels[i, j].OccupyingPlayer == PlayerMark.None)
                    yield return gridModels[i, j];
    }

    public override CellModel GetAvailableBestMove(GridPresenter gridPresenter, PlayerMark currentPlayerMark = PlayerMark.O) =>
        GetBestMove(gridPresenter.Model.GridCells, currentPlayerMark);
}

