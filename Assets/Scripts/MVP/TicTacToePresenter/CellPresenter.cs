using MVP.Presenter;

namespace MVP.Model
{
    public class CellPresenter : BasePresenter
    {
        public void OccupyCell(PlayerMark player, CellModel cell)
        {
            if (!cell.IsOccupied)
            {
                cell.Player = player;
                cell.IsOccupied = true;
                SwitchPlayer();
            }
        }
        
        public void OccupyCell(CellModel model, PlayerMark player)
        {
            if (!model.IsOccupied)
            {
                model.Player = player;
                model.IsOccupied = true;
                SwitchPlayer();
            }
        }
        
        public void DeoccupyCell(CellModel model)
        {
            if (model.IsOccupied)
            {
                model.Player = PlayerMark.None;
                model.IsOccupied = false;
                SwitchPlayer();
            }
        }

        private void SwitchPlayer() => 
            DesignDataContainer.CurrentPlayer = DesignDataContainer.CurrentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    }
}