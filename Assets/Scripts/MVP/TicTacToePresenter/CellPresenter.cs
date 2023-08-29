namespace MVP.Model
{
    public class CellPresenter : Presenter.Presenter
    {
        public readonly CellModel model = new(PlayerMark.None);
        public CellModel Model => model;
        private static PlayerMark _currentPlayer;

        public void OccupyCell(PlayerMark player)
        {
            model.OccupyCell(player);
            SwitchPlayer();
        }

        public void DeoccupyCell(PlayerMark player)
        {
            model.DeoccupyCell(player);
            SwitchPlayer();
        }

        public PlayerMark GetCurrentPlayer() => _currentPlayer;
        private void SwitchPlayer() => _currentPlayer = _currentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    }

}