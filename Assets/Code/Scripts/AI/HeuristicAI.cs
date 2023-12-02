using System.Collections.Generic;
using System.Linq;
using MVP.Model;
using MVP.TicTacToePresenter;
using MVP.TicTacToeView;
using UnityEngine;
using VContainer;


[HelpURL("https://medium.com/@ma274/tic-tac-toe-game-using-heuristic-alpha-beta-tree-search-algorithm-26b13273bc5b")]
public class HeuristicAI : MonoBehaviour
{
    [Inject] private DesignDataContainer _designDataContainer;
    [Inject] private GridView _gridView;
    [Inject] private Referee _referee;

    /// Basic method for obtaining the best move.
    public CellModel GetBestMove(CellModel[,] gridModels, PlayerMark currentPlayer) =>
        CheckForWinningMove(gridModels, currentPlayer) ??
        CheckForWinningMove(gridModels, GetOpponent(currentPlayer)) ??
        OccupyCenterCell(gridModels) ??
        OccupyCornerCell(gridModels) ??
        OccupyAnyAvailableCell(gridModels);
    
    /// Method for checking a possible winning move for the specified player.
    private CellModel CheckForWinningMove(CellModel[,] gridModels, PlayerMark player)
    {
        foreach (var cell in GetAllEmptyCells(gridModels))
        {
            cell.OccupyingPlayer = player;
            if (_referee.CanBeWin(player))
            {
                cell.OccupyingPlayer = PlayerMark.None;
                return cell;
            }
            cell.OccupyingPlayer = PlayerMark.None;
        }
        return null;
    }

    /// Helper method to get all empty cells in the grid.
    private IEnumerable<CellModel> GetAllEmptyCells(CellModel[,] gridModels)
    {
        for (int i = 0; i < _designDataContainer.GRID_SIZE; i++)
        for (int j = 0; j < _designDataContainer.GRID_SIZE; j++)
            if (gridModels[i, j].OccupyingPlayer == PlayerMark.None)
                yield return gridModels[i, j];
    }
    
    /// Gets the opposing player's mark.
    private PlayerMark GetOpponent(PlayerMark currentPlayer) =>
        (currentPlayer == PlayerMark.X) ? PlayerMark.O : PlayerMark.X;

    /// Occupies the center cell if it's available.
    private CellModel OccupyCenterCell(CellModel[,] gridModels) =>
        gridModels[DesignDataContainer.CenterX, DesignDataContainer.CenterY].OccupyingPlayer == PlayerMark.None ? gridModels[DesignDataContainer.CenterX, DesignDataContainer.CenterY] : null;

    /// Method to occupy a corner cell if available.
    private CellModel OccupyCornerCell(CellModel[,] gridModels)
    {
        foreach (int cornerIndex in Enumerable.Range(0, DesignDataContainer.Corners.GetLength(0)))
        {
            int row = DesignDataContainer.Corners[cornerIndex, 0];
            int col = DesignDataContainer.Corners[cornerIndex, 1];
            if (gridModels[row, col].OccupyingPlayer == PlayerMark.None)
                return gridModels[row, col];
        }
        return null;
    }

    /// Occupy any available cell.
    private CellModel OccupyAnyAvailableCell(CellModel[,] gridModels)
    {
        for (int i = 0; i < _designDataContainer.GRID_SIZE; i++)
        for (int j = 0; j < _designDataContainer.GRID_SIZE; j++)
            if (gridModels[i, j].OccupyingPlayer == PlayerMark.None)
                return gridModels[i, j];
        return null;
    }

    /// Getting the best available move for AI.
    public CellModel GetAvailableBestMove(PlayerMark currentPlayerMark = PlayerMark.O)
    {
        int numberOfAttempts = 0;
        GridPresenter gridBasePresenter = _gridView.Presenter;
        CellModel[,] gridModels = gridBasePresenter.Model.GridCells;
        CellModel bestMove = GetBestMove(gridModels, currentPlayerMark);

        // Check if the selected move is free, otherwise try again.
        while (bestMove is { IsOccupied: true } && numberOfAttempts < DesignDataContainer.MaxAttempts)
        {
            bestMove = GetBestMove(gridModels, currentPlayerMark);
            numberOfAttempts++;
        }
        return numberOfAttempts == DesignDataContainer.MaxAttempts ? null : bestMove;
    }
}