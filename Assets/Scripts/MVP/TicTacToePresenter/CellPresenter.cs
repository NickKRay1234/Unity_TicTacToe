using MVP.Presenter;

namespace MVP.Model
{
    public class CellPresenter : BasePresenter, IOccupiable, IDeoccupiable
    { 
        public void OccupyCell(CellModel model, PlayerMark player)
        {
            if (!model.IsOccupied)
            {
                model.OccupyingPlayer = player;
                model.IsOccupied = true;
            }
        }
        
        public void DeoccupyCell(CellModel model)
        {
            if (model.IsOccupied)
            {
                model.OccupyingPlayer = PlayerMark.None;
                model.IsOccupied = false;
                SwitchPlayer();
            }
        }

        public void SwitchPlayer() => 
            DesignDataContainer.CurrentPlayer = DesignDataContainer.CurrentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    }
}