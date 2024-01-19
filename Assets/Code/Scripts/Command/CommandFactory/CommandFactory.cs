using SignFactory;
using UnityEngine;

namespace MVP.Model
{
    /// Factory for creating commands. Provides methods for creating commands for the player and AI.
    public class CommandFactory
    {
        private readonly CellPresenter _cellPresenter;
        private readonly DesignDataContainer _designDataContainer;
        private readonly X_Factory _xFactory;
        private readonly O_Factory _oFactory;

        public CommandFactory(CellPresenter cellPresenter, X_Factory xFactory, O_Factory oFactory,
            DesignDataContainer designDataContainer)
        {
            _cellPresenter = cellPresenter;
            _xFactory = xFactory;
            _oFactory = oFactory;
            _designDataContainer = designDataContainer;
        }

        public ICommand CreatePlayerCommand(CellModel cellModel, Transform transform)
        {
            var data = GetParameters(transform, cellModel);
            return new PlayerMarkCommand(data);
        }

        public ICommand CreateAICommand(CellModel cellModel, Transform transform, HeuristicAI heuristicAI)
        {
            var data = GetParameters(transform, cellModel);
            var playerMoveCommand = new PlayerMoveCommand(data);
            var aiMoveCommand = new AIMoveCommand(data, heuristicAI);
            return new CompositeCommand(playerMoveCommand, aiMoveCommand);
        }
        
        private CommandParameters GetParameters(Transform transform, CellModel cellModel) =>
            new(_designDataContainer, _xFactory, _oFactory, _cellPresenter, transform, cellModel);
    }
}