using SignFactory;
using UnityEngine;

namespace MVP.Model
{
    public class CommandFactory
    {
        private readonly CellPresenter _cellPresenter;
        private DesignDataContainer _designDataContainer;
        private X_Factory _xFactory;
        private O_Factory _oFactory;

        public CommandFactory(DesignDataContainer designDataContainer, X_Factory xFactory, O_Factory oFactory,
            CellPresenter cellPresenter)
        {
            _cellPresenter = cellPresenter;
            _designDataContainer = designDataContainer;
            _xFactory = xFactory;
            _oFactory = oFactory;
        }

        public ICommand CreatePlayerCommand(CellModel cellModel, Transform transform) =>
            new PlayerMarkCommand(_designDataContainer, _xFactory, _oFactory, _cellPresenter, transform, cellModel);

        public ICommand CreateAICommand(CellModel cellModel, Transform transform, HeuristicAI heuristicAI)
        {
            var playerMoveCommand = new PlayerMoveCommand(_designDataContainer, _xFactory, _oFactory, _cellPresenter,
                transform, cellModel);
            var aiMoveCommand = new AIMoveCommand(_designDataContainer, _xFactory, _oFactory, _cellPresenter, transform,
                cellModel, heuristicAI);
            return new CompositeCommand(playerMoveCommand, aiMoveCommand);
        }
    }
}