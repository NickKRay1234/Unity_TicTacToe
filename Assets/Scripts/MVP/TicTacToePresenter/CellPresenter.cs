using MVP.Presenter;

namespace MVP.Model
{
    public class CellPresenter : BasePresenter, IOccupy, IDeoccupy
    { 
        public void OccupyCell(CellModel model, PlayerMark player)
        {
            if (!model.IsOccupied)
            {
                model.Player = player;
                model.IsOccupied = true;
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

        public void SwitchPlayer() => 
            DesignDataContainer.CurrentPlayer = DesignDataContainer.CurrentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    }
}