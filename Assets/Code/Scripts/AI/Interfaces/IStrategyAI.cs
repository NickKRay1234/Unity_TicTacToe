using System;
using MVP.Model;
using MVP.TicTacToePresenter;

public interface IStrategyAI
{
    CellModel GetAvailableBestMove(GridPresenter gridPresenter, PlayerMark currentPlayerMark = PlayerMark.O);
    event Predicate<PlayerMark> CheckWinEvent;
}