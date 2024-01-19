using MVP.Model;
using MVP.TicTacToePresenter;

public interface IAIStrategy
{
    CellModel GetBestMove(CellModel[,] gridModels, PlayerMark currentPlayer);
    CellModel GetAvailableBestMove(GridPresenter gridPresenter, PlayerMark currentPlayerMark = PlayerMark.O);
}