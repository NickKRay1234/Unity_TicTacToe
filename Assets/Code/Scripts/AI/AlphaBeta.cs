using System;
using MVP.Model;
using MVP.TicTacToePresenter;
using UnityEngine;

public class AlphaBeta : MonoBehaviour, IAIStrategy
{
    private const int MAX_SCORE = 10;
    private const int MIN_SCORE = -10;

    // Основной метод для получения лучшего хода
    public CellModel GetBestMove(CellModel[,] gridModels, PlayerMark currentPlayer)
    {
        int bestValue = MIN_SCORE;
        CellModel bestMove = null;

        for (int i = 0; i < gridModels.GetLength(0); i++)
        {
            for (int j = 0; j < gridModels.GetLength(1); j++)
            {
                if (gridModels[i, j].OccupyingPlayer == PlayerMark.None)
                {
                    gridModels[i, j].OccupyingPlayer = currentPlayer;
                    int moveValue = MinMax(gridModels, 0, false, currentPlayer, MIN_SCORE, MAX_SCORE);
                    gridModels[i, j].OccupyingPlayer = PlayerMark.None;

                    if (moveValue > bestValue)
                    {
                        bestMove = gridModels[i, j];
                        bestValue = moveValue;
                    }
                }
            }
        }
        return bestMove;
    }

    public CellModel GetAvailableBestMove(GridPresenter gridPresenter, PlayerMark currentPlayerMark = PlayerMark.O)
    {
        CellModel[,] gridModels = gridPresenter.Model.GridCells;
        return GetBestMove(gridModels, currentPlayerMark);
    }

    public event Predicate<PlayerMark> CheckWinEvent;

    // Рекурсивная функция MinMax с альфа-бета отсечением
    private int MinMax(CellModel[,] gridModels, int depth, bool isMaximizing, PlayerMark player, int alpha, int beta)
    {
        int score = Evaluate(gridModels, player);

        if (score == MAX_SCORE || score == MIN_SCORE || !IsMovesLeft(gridModels))
            return score;

        if (isMaximizing)
        {
            int best = MIN_SCORE;
            for (int i = 0; i < gridModels.GetLength(0); i++)
            {
                for (int j = 0; j < gridModels.GetLength(1); j++)
                {
                    if (gridModels[i, j].OccupyingPlayer == PlayerMark.None)
                    {
                        gridModels[i, j].OccupyingPlayer = player;
                        best = Math.Max(best, MinMax(gridModels, depth + 1, false, GetOpponent(player), alpha, beta));
                        gridModels[i, j].OccupyingPlayer = PlayerMark.None;
                        alpha = Math.Max(alpha, best);
                        if (beta <= alpha)
                            break;
                    }
                }
            }
            return best;
        }
        else
        {
            int best = MAX_SCORE;
            for (int i = 0; i < gridModels.GetLength(0); i++)
            {
                for (int j = 0; j < gridModels.GetLength(1); j++)
                {
                    if (gridModels[i, j].OccupyingPlayer == PlayerMark.None)
                    {
                        gridModels[i, j].OccupyingPlayer = player;
                        best = Math.Min(best, MinMax(gridModels, depth + 1, true, GetOpponent(player), alpha, beta));
                        gridModels[i, j].OccupyingPlayer = PlayerMark.None;
                        beta = Math.Min(beta, best);
                        if (beta <= alpha)
                            break;
                    }
                }
            }
            return best;
        }
    }

    // Оценка текущего состояния доски
    private int Evaluate(CellModel[,] gridModels, PlayerMark player)
    {
        // Проверяем, есть ли выигрышная комбинация для игрока
        if (CheckWin(gridModels, player))
            return 10; // Возвращает положительное значение, если игрок выиграл

        // Проверяем, есть ли выигрышная комбинация для противника
        PlayerMark opponent = player == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
        if (CheckWin(gridModels, opponent))
            return -10; // Возвращает отрицательное значение, если противник выиграл

        return 0; // Возвращает 0, если никто не выиграл
    }

    // Получение противоположного игрока
    private PlayerMark GetOpponent(PlayerMark currentPlayer) =>
        currentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    
    private bool CheckWin(CellModel[,] gridModels, PlayerMark player)
    {
        // Проходим по всем ячейкам и делаем временные изменения для проверки выигрыша
        for (int i = 0; i < gridModels.GetLength(0); i++)
        {
            for (int j = 0; j < gridModels.GetLength(1); j++)
            {
                if (gridModels[i, j].OccupyingPlayer == PlayerMark.None)
                {
                    // Делаем временный ход
                    gridModels[i, j].OccupyingPlayer = player;

                    // Проверяем, является ли этот ход выигрышным
                    bool isWinningMove = CheckWinEvent?.Invoke(player) ?? false;

                    // Отменяем временный ход
                    gridModels[i, j].OccupyingPlayer = PlayerMark.None;

                    if (isWinningMove)
                    {
                        // Если найден выигрышный ход, возвращаем true
                        return true;
                    }
                }
            }
        }

        // Если выигрышный ход не найден, возвращаем false
        return false;
    }
    
    // Проверка, остались ли ходы
    private bool IsMovesLeft(CellModel[,] gridModels)
    {
        for (int i = 0; i < gridModels.GetLength(0); i++)
        for (int j = 0; j < gridModels.GetLength(1); j++)
            if (gridModels[i, j].OccupyingPlayer == PlayerMark.None)
                return true;

        return false;
    }

}