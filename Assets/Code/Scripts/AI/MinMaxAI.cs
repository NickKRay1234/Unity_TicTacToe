using MVP.Model;
using MVP.TicTacToePresenter;
using UnityEngine;

public class MinMaxAI : MonoBehaviour, IAIStrategy
{
    // Метод для получения лучшего хода с использованием алгоритма MinMax
    public CellModel GetBestMove(CellModel[,] gridModels, PlayerMark currentPlayer)
    {
        return new CellModel(2, 2);
        // Здесь должна быть реализация алгоритма MinMax
        // Возвращаем результат алгоритма MinMax
    }

    public CellModel GetAvailableBestMove(GridPresenter gridPresenter, PlayerMark currentPlayerMark = PlayerMark.O)
    {
        return new CellModel(2, 2);
    }

    // ... дополнительные методы и логика, специфичная для MinMax ...
}