using System;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Model
{
    public class CellPresenter : ICellStateChangeable
    {
        private readonly DesignDataContainer _designDataContainer;

        public CellPresenter(DesignDataContainer designDataContainer) =>
            _designDataContainer = designDataContainer ?? throw new ArgumentNullException(nameof(designDataContainer));
        
        public bool IsCellOccupied(CellModel model) => model.IsOccupied;

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
        
        public void PlaceCurrentPlayerMark(CellModel cellModel, Transform transform, Image image, bool isGameWithAI, CommandInvoker invoker, HeuristicAI heuristicAI)
        {
            if (!IsCellOccupied(cellModel))
            {
                if (isGameWithAI)
                    invoker.Execute(new CompositeCommand(new PlayerMoveCommand(this, transform, image, cellModel), new AIMoveCommand(this, transform, image, cellModel, heuristicAI)));
                else 
                    invoker.Execute(new PlayerMarkCommand(this, transform, image, cellModel, _designDataContainer));
            }
        }
        
        public void SwitchPlayer() =>
            _designDataContainer.CurrentPlayer = _designDataContainer.CurrentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    }
}