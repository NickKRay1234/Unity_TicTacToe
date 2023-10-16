using System;
using SignFactory;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Model
{
    public class CellPresenter : ICellStateChangeable
    {
        private readonly X_Factory _xFactory;
        private readonly O_Factory _oFactory;
        private readonly DesignDataContainer _designDataContainer;

        public CellPresenter(DesignDataContainer designDataContainer, X_Factory xFactory, O_Factory oFactory)
        {
            _designDataContainer = designDataContainer ?? throw new ArgumentNullException(nameof(designDataContainer));
            _xFactory = xFactory ?? throw new ArgumentNullException(nameof(xFactory));
            _oFactory = oFactory ?? throw new ArgumentNullException(nameof(oFactory));
        }

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

        public void PlaceCurrentPlayerMark(CellModel cellModel, Transform transform, Image image, bool isGameWithAI,
            CommandInvoker invoker, HeuristicAI heuristicAI)
        {
            if (!IsCellOccupied(cellModel))
            {
                if (isGameWithAI)
                    invoker.Execute(new CompositeCommand(
                        new PlayerMoveCommand(_designDataContainer, _xFactory, _oFactory, this, transform, image,
                            cellModel),
                        new AIMoveCommand(_designDataContainer, _xFactory, _oFactory, this, transform, image, cellModel,
                            heuristicAI)));
                else
                    invoker.Execute(new PlayerMarkCommand(_designDataContainer, _xFactory, _oFactory, this, transform,
                        image, cellModel));
            }
        }

        public void SwitchPlayer() =>
            _designDataContainer.CurrentPlayer =
                _designDataContainer.CurrentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    }
}