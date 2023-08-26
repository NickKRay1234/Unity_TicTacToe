using UnityEngine;

namespace MVP.Model
{
    public class CellPresenter : Presenter.Presenter
    {
        public readonly CellModel model = new();
        public CellModel Model => model;
        private static string _currentPlayer = "X";

        public void OccupyCell(string player)
        {
            model.OccupyCell(player);
            SwitchPlayer();
        }

        public Vector3 GetCurrentCellPosition() => new(model.X, model.Y, 0);
        public string GetCurrentPlayer() => _currentPlayer;
        private void SwitchPlayer() => _currentPlayer = _currentPlayer == "X" ? "O" : "X";
    }

}