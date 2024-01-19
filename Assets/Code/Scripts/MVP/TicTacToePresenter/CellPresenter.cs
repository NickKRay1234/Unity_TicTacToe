using System;
using UnityEngine;

namespace MVP.Model
{
    [HelpURL("https://unity.com/how-to/build-modular-codebase-mvc-and-mvp-programming-patterns")]
    public class CellPresenter
    {
        private readonly DesignDataContainer _designDataContainer;

        public CellPresenter(DesignDataContainer designDataContainer) =>
            _designDataContainer = designDataContainer ?? throw new ArgumentNullException(nameof(designDataContainer));

        public bool IsCellOccupied(CellModel model) => model.IsOccupied;

        /// Occupies a cell with a player's mark if it's not already occupied
        public void OccupyCell(CellModel model, PlayerMark player)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (model.IsOccupied) return;
            model.OccupyingPlayer = player;
            model.IsOccupied = true;
        }

        /// Deoccupies a cell and switches the current player
        public void DeoccupyCell(CellModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (!model.IsOccupied) return;
            model.OccupyingPlayer = PlayerMark.None;
            model.IsOccupied = false;
            ToggleCurrentPlayer();
        }

        /// Places a mark in a cell if it's free and executes the corresponding command
        public void PlaceMarkIfCellFree(CellModel cellModel, Transform transform, CommandInvoker invoker, CommandFactory commandFactory,
            bool isGameWithAI = false, IAIStrategy aiStrategy = null)
        {
            if (cellModel == null) throw new ArgumentNullException(nameof(cellModel));
            if (IsCellOccupied(cellModel)) return;
            ICommand command = CreateAppropriateCommand(cellModel, transform, commandFactory, isGameWithAI, aiStrategy);
            invoker.Execute(command);
        }

        /// Determines which command to create based on the game state
        private ICommand CreateAppropriateCommand(CellModel cellModel, Transform transform,
            CommandFactory commandFactory, bool isGameWithAI, IAIStrategy aiStrategy) =>
            isGameWithAI
                ? commandFactory.CreateAICommand(cellModel, transform, aiStrategy)
                : commandFactory.CreatePlayerCommand(cellModel, transform);

        /// Toggles between player X and player O
        public void ToggleCurrentPlayer() =>
            _designDataContainer.CurrentPlayer =
                _designDataContainer.CurrentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    }
}