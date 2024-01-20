using System;
using MVP.Model;
using MVP.TicTacToePresenter;
using UnityEngine;

[HelpURL("https://refactoring.guru/ru/design-patterns/strategy")]
public abstract class BaseStrategyAI : MonoBehaviour, IStrategyAI
{
    protected const int MAX_SCORE = 10;
    protected const int MIN_SCORE = -10;
    protected event Predicate<PlayerMark> CheckWinEvent;

    public abstract CellModel GetAvailableBestMove(GridPresenter gridPresenter,
        PlayerMark currentPlayerMark = PlayerMark.O);

    event Predicate<PlayerMark> IStrategyAI.CheckWinEvent
    {
        add => CheckWinEvent += value;
        remove => CheckWinEvent -= value;
    }

    /// Checks if there are any moves left on the grid
    protected bool IsMovesLeft(CellModel[,] gridModels)
    {
        for (int i = 0; i < gridModels.GetLength(0); i++)
        for (int j = 0; j < gridModels.GetLength(1); j++)
            if (gridModels[i, j].OccupyingPlayer == PlayerMark.None)
                return true;

        return false;
    }

    /// Checks for a win condition
    protected bool CheckWin(CellModel[,] gridModels, PlayerMark player)
    {
        // Evaluate every cell to check for a winning move
        for (int i = 0; i < gridModels.GetLength(0); i++)
        for (int j = 0; j < gridModels.GetLength(1); j++)
            if (gridModels[i, j].OccupyingPlayer == PlayerMark.None)
            {
                gridModels[i, j].OccupyingPlayer = player;
                bool isWinningMove = CheckWinEvent?.Invoke(player) ?? false;
                gridModels[i, j].OccupyingPlayer = PlayerMark.None;
                if (isWinningMove) return true;
            }

        return false;
    }

    protected PlayerMark GetOpponent(PlayerMark currentPlayer) =>
        currentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
}