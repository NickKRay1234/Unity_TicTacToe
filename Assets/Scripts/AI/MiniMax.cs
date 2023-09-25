using MVP.Model;
using MVP.TicTacToePresenter;
using MVP.TicTacToeView;
using UnityEngine;

public class MiniMax : MonoBehaviour, IService
{
    private Referee _referee;
    private GridPresenter _presenter;

    private void Start()
    {
        _referee = ServiceLocator.Current.Get<Referee>();
        _presenter = ServiceLocator.Current.Get<GridView>().GridPresenter;
    }


    int MinMax(CellModel[,] gridCells, PlayerMark currentPlayer)
    {
        int score = (currentPlayer == PlayerMark.X) ? int.MaxValue : int.MinValue;
        for (int i = 0; i < GridModel.GRID_SIZE; i++)
        for (int j = 0; j < GridModel.GRID_SIZE; j++)
            if (gridCells[i, j].Player == PlayerMark.None)
            {
                gridCells[i, j].Player = currentPlayer;
                int currentScore = MinMax(gridCells, (currentPlayer == PlayerMark.X) ? PlayerMark.O : PlayerMark.X);
                gridCells[i, j].Player = PlayerMark.None;
                if ((currentPlayer == PlayerMark.X && currentScore < score) ||
                    (currentPlayer == PlayerMark.O && currentScore > score))
                    score = currentScore;
            }

        return score;
    }

    public CellModel FindBestMove(CellModel[,] gridModels)
    {
        int bestValue = int.MinValue;
        int bestRow = -1, bestCol = -1;

        for (int i = 0; i < GridModel.GRID_SIZE; i++)
        for (int j = 0; j < GridModel.GRID_SIZE; j++)
            if (gridModels[i, j].Player == PlayerMark.None)
            {
                gridModels[i, j].Player = PlayerMark.O;
                int moveValue = MinMax(gridModels, PlayerMark.X);
                gridModels[i, j].Player = PlayerMark.None;

                if (moveValue > bestValue)
                {
                    bestRow = i;
                    bestCol = j;
                    bestValue = moveValue;
                }
            }
        GridModel grid = ServiceLocator.Current.Get<GridView>().GridPresenter.Model;
        
        return grid.GridCells[bestRow, bestCol];
    }
}