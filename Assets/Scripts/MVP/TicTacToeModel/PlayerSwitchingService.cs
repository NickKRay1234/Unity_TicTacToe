using System;

namespace MVP.Model
{
    public class PlayerSwitchingService
    {
        private readonly DesignDataContainer _designDataContainer;

        public PlayerSwitchingService(DesignDataContainer designDataContainer)
        {
            _designDataContainer = designDataContainer ?? throw new ArgumentNullException(nameof(designDataContainer));
        }

        public void SwitchPlayer() =>
            _designDataContainer.CurrentPlayer = _designDataContainer.CurrentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    }
}