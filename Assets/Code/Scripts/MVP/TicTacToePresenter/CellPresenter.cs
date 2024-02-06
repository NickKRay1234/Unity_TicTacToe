using System;
using SignFactory;
using UnityEngine;
using VContainer;

namespace MVP.Model
{
    [HelpURL("https://unity.com/how-to/build-modular-codebase-mvc-and-mvp-programming-patterns")]
    public class CellPresenter
    {
        [Inject] private Cell_Factory _cellFactory;
        
        private readonly CellModel _model;
        private readonly CellView _view;
        private readonly CommandFactory _commandFactory;
        private readonly DesignDataContainer _designDataContainer;

        public CellPresenter(CellModel model, CellView view, CommandFactory commandFactory, DesignDataContainer designDataContainer)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _designDataContainer = designDataContainer;
            _commandFactory = commandFactory;

            _view.Initialize(this);
        }

        public bool IsCellOccupied(CellModel model) => model.IsOccupied;
        
        /// Places a mark in a cell if it's free and executes the corresponding command
        public void PlaceMarkIfCellFree(CellModel cellModel, Transform transform, CommandFactory commandFactory,
            bool isGameWithAI = false)
        {
            if (cellModel == null) throw new ArgumentNullException(nameof(cellModel));
            if (IsCellOccupied(cellModel)) return;
            ICommand command = CreateAppropriateCommand(cellModel, transform, commandFactory, isGameWithAI);
            command.Execute();
        }

        /// Determines which command to create based on the game state
        private ICommand CreateAppropriateCommand(CellModel cellModel, Transform transform,
            CommandFactory commandFactory, bool isGameWithAI) =>
            isGameWithAI
                ? commandFactory.CreateAICommand(cellModel, transform)
                : commandFactory.CreatePlayerCommand(cellModel, transform);
        
        
        public void CellClicked()
        {
            if (_model.IsOccupied) return;

            // Обновление модели
            var currentPlayer = _designDataContainer.CurrentPlayer;
            _model.OccupyingPlayer = currentPlayer;

            // Выполнение команды
            PlaceMarkIfCellFree(_model, _view.transform, _commandFactory);


            // Обновление View
            //_view.UpdateView(_model.OccupyingPlayer);
        }
    }
}