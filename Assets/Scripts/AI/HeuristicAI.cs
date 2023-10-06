using MVP.Model;
using MVP.TicTacToePresenter;
using MVP.TicTacToeView;

public class HeuristicAI
{
    // Returns the best move for the given player based on a heuristic approach.
    public CellModel GetBestMove(CellModel[,] gridModels, PlayerMark currentPlayer)
    {
        // 1. Check if the AI can win in the next move.
        for (int i = 0; i < DesignDataContainer.GRID_SIZE; i++)
        {
            for (int j = 0; j < DesignDataContainer.GRID_SIZE; j++)
            {
                if (gridModels[i, j].Player == PlayerMark.None)
                {
                    gridModels[i, j].Player = currentPlayer;
                    if (ServiceLocator.Current.Get<Referee>().CanBeWin(currentPlayer))
                    {
                        gridModels[i, j].Player = PlayerMark.None;
                        return gridModels[i, j];
                    }
                    gridModels[i, j].Player = PlayerMark.None;
                }
            }
        }
        
        // 2. Check if the opponent can win in the next move.
        PlayerMark opponent = (currentPlayer == PlayerMark.X) ? PlayerMark.O : PlayerMark.X;
        for (int i = 0; i < DesignDataContainer.GRID_SIZE; i++)
        {
            for (int j = 0; j < DesignDataContainer.GRID_SIZE; j++)
            {
                if (gridModels[i, j].Player == PlayerMark.None)
                {
                    gridModels[i, j].Player = opponent;
                    if (ServiceLocator.Current.Get<Referee>().CanBeWin(opponent))
                    {
                        gridModels[i, j].Player = PlayerMark.None;
                        return gridModels[i, j];
                    }
                    gridModels[i, j].Player = PlayerMark.None;
                }
            }
        }
        
        // 3. Try to occupy the center cell.
        if (gridModels[1, 1].Player == PlayerMark.None)
        {
            return gridModels[1, 1];
        }

        // 4. Try to occupy a corner cell.
        int[,] corners = { { 0, 0 }, { 0, 2 }, { 2, 0 }, { 2, 2 } };
        for (int i = 0; i < 4; i++)
        {
            if (gridModels[corners[i, 0], corners[i, 1]].Player == PlayerMark.None)
            {
                return gridModels[corners[i, 0], corners[i, 1]];
            }
        }

        // 5. Occupy any available cell.
        for (int i = 0; i < DesignDataContainer.GRID_SIZE; i++)
        {
            for (int j = 0; j < DesignDataContainer.GRID_SIZE; j++)
            {
                if (gridModels[i, j].Player == PlayerMark.None)
                {
                    return gridModels[i, j];
                }
            }
        }

        // Return null if all cells are occupied.
        return null;
    }
    
    public CellModel GetAvailableBestMove(PlayerMark currentPlayerMark = PlayerMark.O)
    {
        const int MaxAttempts = 10;
        int numberOfAttempts = 0;
        
        GridPresenter gridBasePresenter = ServiceLocator.Current.Get<GridView>().GridBasePresenter;
        CellModel[,] gridModels = gridBasePresenter.Model.GridCells;

        CellModel bestMove = GetBestMove(gridModels, currentPlayerMark);
        while (bestMove is { IsOccupied: true } && numberOfAttempts < MaxAttempts)
        {
            bestMove = GetBestMove(gridModels, currentPlayerMark);
            numberOfAttempts++;
        }

        return numberOfAttempts == MaxAttempts ? null : bestMove;
    }
}

