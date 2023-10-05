using MVP.Presenter;
using UnityEngine;

namespace MVP.Model
{
    public class CellPresenter : BasePresenter
    {
        public ICellModel Model { get; } = new CellModel(0, 0);

        public void OccupyCell(PlayerMark player, CellModel cell)
        {
            if (!Model.IsOccupied)
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

        public void DeoccupyCell()
        {
            if (Model.IsOccupied)
            {
                Model.Player = PlayerMark.None;
                Model.IsOccupied = false;
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