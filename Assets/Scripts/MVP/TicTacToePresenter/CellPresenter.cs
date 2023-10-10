using System;

namespace MVP.Model
{
    public class CellPresenter : ICellStateChangeable
    {
        private readonly DesignDataContainer _designDataContainer;

        public CellPresenter(DesignDataContainer designDataContainer) =>
            _designDataContainer = designDataContainer ?? throw new ArgumentNullException(nameof(designDataContainer));

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
            _designDataContainer.CurrentPlayer = _designDataContainer.CurrentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    }
}