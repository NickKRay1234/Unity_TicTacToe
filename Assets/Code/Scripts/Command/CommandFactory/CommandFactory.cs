using MVP.TicTacToePresenter;
using SignFactory;
using UnityEngine;
using VContainer;

namespace MVP.Model
{
    /// Factory for creating commands. Provides methods for creating commands for the player and AI.
    public class CommandFactory
    {
        private readonly GridPresenter _gridPresenter;
        
        [Inject] private X_Factory _xFactory;
        [Inject] private O_Factory _oFactory;
        private DesignDataContainer _designDataContainer;

        public CommandFactory(GridPresenter gridPresenter, DesignDataContainer designDataContainer)
        {
            _gridPresenter = gridPresenter;
            _designDataContainer = designDataContainer;
        }

        public ICommand CreatePlayerCommand(CellModel cellModel, Transform transform)
        {
            var data = GetParameters(transform, cellModel);
            return new PlayerMarkCommand(data);
        }

        public ICommand CreateAICommand(CellModel cellModel, Transform transform)
        {
            var data = GetParameters(transform, cellModel);
            var playerMoveCommand = new PlayerMoveCommand(data);
            var aiMoveCommand = new AIMoveCommand(data, _gridPresenter);
            return new CompositeCommand(playerMoveCommand, aiMoveCommand);
        }
        
        private CommandParameters GetParameters(Transform transform, CellModel cellModel) =>
            new(_designDataContainer, _xFactory, _oFactory, transform, cellModel);
    }
}