using System;
using System.Collections.Generic;
using System.Linq;
using MVP.Model;
using MVP.TicTacToePresenter;

public sealed class AlphaBetaStrategyAI : BaseStrategyAI
{
    public override CellModel GetAvailableBestMove(GridPresenter gridPresenter, PlayerMark currentPlayerMark = PlayerMark.O) =>
        GetBestMove(gridPresenter.Model.GridCells, currentPlayerMark);

    public CellModel GetBestMove(CellModel[,] gridModels, PlayerMark currentPlayer) =>
        gridModels.Cast<CellModel>()
            .Where(cell => cell.OccupyingPlayer == PlayerMark.None)
            .Select(cell => new { Cell = cell, Score = EvaluateMove(cell, currentPlayer, gridModels) })
            .OrderByDescending(x => x.Score)
            .FirstOrDefault()?.Cell;

    private int EvaluateMove(CellModel cell, PlayerMark currentPlayer, CellModel[,] gridModels)
    {
        cell.OccupyingPlayer = currentPlayer;
        var score = AlphaBeta(gridModels, 0, false, currentPlayer, MIN_SCORE, MAX_SCORE);
        cell.OccupyingPlayer = PlayerMark.None;
        return score;
    }

    private int AlphaBeta(CellModel[,] gridModels, int depth, bool isMaximizing, PlayerMark player, int alpha, int beta) =>
        IsTerminalNode(gridModels, player) 
            ? EvaluateBoard(gridModels, player) : (isMaximizing ? GetMaxScore(gridModels, player, depth, alpha, beta) : GetMinScore(gridModels, player, depth, alpha, beta));

    private bool IsTerminalNode(CellModel[,] gridModels, PlayerMark player) => 
        !IsMovesLeft(gridModels) || Math.Abs(EvaluateBoard(gridModels, player)) == MAX_SCORE;

    private int GetMaxScore(CellModel[,] gridModels, PlayerMark player, int depth, int alpha, int beta)
    {
        var bestScore = MIN_SCORE;
        foreach (var cell in GetAllEmptyCells(gridModels))
        {
            bestScore = EvaluateAndUpdate(cell, gridModels, player, depth, alpha, beta, bestScore, false);
            alpha = Math.Max(alpha, bestScore);
            if (beta <= alpha) break;
        }
        return bestScore;
    }

    private int GetMinScore(CellModel[,] gridModels, PlayerMark player, int depth, int alpha, int beta)
    {
        var bestScore = MAX_SCORE;
        foreach (var cell in GetAllEmptyCells(gridModels))
        {
            bestScore = EvaluateAndUpdate(cell, gridModels, player, depth, alpha, beta, bestScore, true);
            beta = Math.Min(beta, bestScore);
            if (beta <= alpha) break;
        }
        return bestScore;
    }

    private int EvaluateAndUpdate(CellModel cell, CellModel[,] gridModels, PlayerMark player, int depth, int alpha, int beta, int currentBest, bool minimizing)
    {
        UpdateCell(cell, player);
        var score = AlphaBeta(gridModels, depth + 1, minimizing, GetOpponent(player), alpha, beta);
        ResetCell(cell);
        return minimizing ? Math.Min(currentBest, score) : Math.Max(currentBest, score);
    }
    
    private void UpdateCell(CellModel cell, PlayerMark player) => cell.OccupyingPlayer = player;
    private void ResetCell(CellModel cell) => cell.OccupyingPlayer = PlayerMark.None;
    
    private int EvaluateBoard(CellModel[,] gridModels, PlayerMark player) =>
        CheckWin(gridModels, player) ? MAX_SCORE : (CheckWin(gridModels, GetOpponent(player)) ? MIN_SCORE : 0);
    
    private IEnumerable<CellModel> GetAllEmptyCells(CellModel[,] gridModels) =>
        gridModels.Cast<CellModel>().Where(cell => cell.OccupyingPlayer == PlayerMark.None);
}
   
