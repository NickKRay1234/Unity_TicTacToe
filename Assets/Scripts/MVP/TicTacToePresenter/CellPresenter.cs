namespace MVP.Model
{
    public class CellPresenter : Presenter.Presenter
    {
        public readonly CellModel model = new(PlayerMark.None);
        public CellModel Model => model;
        public static PlayerMark CurrentPlayer;

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

        public PlayerMark GetCurrentPlayer() => CurrentPlayer;
        private void SwitchPlayer() => CurrentPlayer = CurrentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    }

}